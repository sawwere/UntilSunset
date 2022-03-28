using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float xSpeed = 1.5f;
    public float ySpeed = 1.25f;

    //public float timeInvincible = 2.0f;

    public Rigidbody2D rigidbBody2D;
    Vector2 moveDelta;

    public Animator animator;

    public bool isBat;
    private bool isTurning;

    public bool atHome;

    private TimeCycle timeCycle;

    public GameObject Bat;

    private Resources HenchmanRes;
    private Resources resources;

    private int sotringOrderBase = 1000;
    private SortingGroup mySortingGroup;
    private int batOffset = 0;

    private float positionRendererTimer;
    private float positionRendererTimerMax = .1f;
    private float thunderAbilityPeriod = 1.0f;
    private float thunderAbilityTimer;

    private Vector3 batSpawnPosition;
    public static int henchmanLine;

    public GameObject nimb;
    private bool isGod;

    private int coinAmount;
    private int woodAmount;
    private int stoneAmount;
    private int henchmanAmount;

    private AudioSource source;
    public AudioClip[] walksounds;
    private bool isWalking;
    private bool soundIsPlaying;
    private bool onTheWay;
    public bool isTutorial;
    private bool[] sIsPlaying;

    //private int henchmanLine;
    private void Awake()
    {
        mySortingGroup = gameObject.GetComponent<SortingGroup>();
        rigidbBody2D = GetComponent<Rigidbody2D>();
        HenchmanRes = GameObject.Find("HenchmenText").GetComponent<Resources>();
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycle>();
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        source = gameObject.GetComponent<AudioSource>();
    }

    protected virtual void Start()
    {
        animator.SetFloat("LastVertical", -1);
        isBat = false;
        atHome = true;
        isWalking = false;
        onTheWay = false;
        soundIsPlaying = false;
        sIsPlaying = new bool[] { false, false, false };
        thunderAbilityTimer = 0;
        //SetGodSettings();
    }

    protected virtual void Update()
    {
        InvokeCheatCode();

        //thunderAbilityTimer -= Time.deltaTime;
        if (isTurning) return;

        Turning();

        if (isBat || !timeCycle.GetIsDay()) return;

        SpawnBat();

        SubdueEnemy();
    }

    protected virtual void FixedUpdate()
    {
        if (isTurning) return;

        UpdateMotor();
        PlayWalkSound();
    }

    private void LateUpdate()
    {
        SerSortingLayer();
    }

    private void SerSortingLayer()
    {
        positionRendererTimer -= Time.deltaTime;
        if (positionRendererTimer <= 0f)
        {
            positionRendererTimer = positionRendererTimerMax;
            mySortingGroup.sortingOrder = (int)(sotringOrderBase - transform.position.y * 10 - batOffset);
        }
    }

    private void Turning()
    {
        if (Input.GetButtonDown("Jump") && (atHome || !timeCycle.GetIsDay()))
        {
            if (!isBat)
            {
                TurnIntoBat();
            }
            else
            {
                TurnIntoCharacter();
            }
        }
    }

    public void TurnIntoBat()
    {
        isTurning = true;
        isBat = true;
        animator.Play("ToBat");
        Invoke(nameof(SetBatSettings), 0.55f);
    }

    private void TurnIntoCharacter()
    {
        isTurning = true;
        isBat = false;
        animator.Play("ToCharacter");
        Invoke(nameof(SetCharacterSettings), 0.5f);
    }

    private void SetBatSettings()
    {
        animator.Play("Bat");
        isTurning = false;
        isBat = true;
        batOffset = 7;
        xSpeed = 10f;
        ySpeed = 8f;
    }

    public void SetCharacterSettings()
    {
        animator.SetFloat("LastHorizontal", 0);
        animator.SetFloat("LastVertical", -1);
        animator.Play("Idle");
        isTurning = false;
        isBat = false;
        batOffset = 0;
        xSpeed = 1.5f;
        ySpeed = 1.25f;
    }

    private void SetGodSettings() 
    {
        isGod = true;
        nimb.SetActive(true);
        coinAmount = GameStats.Coins;
        woodAmount = GameStats.Wood;
        stoneAmount = GameStats.Stone;
        henchmanAmount = GameStats.Henchman;
        GameStats.Coins = 666;
        GameStats.Wood = 666;
        GameStats.Stone = 666;
        GameStats.Henchman = 666;
        resources.UpdateAll();
    }

    private void UnsetGodSettings()
    {
        isGod = false;
        nimb.SetActive(false);
        GameStats.Coins = coinAmount;
        GameStats.Wood = woodAmount;
        GameStats.Stone = stoneAmount;
        GameStats.Henchman = henchmanAmount;
        resources.UpdateAll();
    }

    private void UpdateMotor()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0) isWalking = true;
        else isWalking = false;

        moveDelta = new Vector2(x * xSpeed, y * ySpeed);

        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);
        animator.SetFloat("Speed", moveDelta.sqrMagnitude);

        if (Math.Abs(x) == 1 || Math.Abs(y) == 1)
        {
            animator.SetFloat("LastHorizontal", x);
            animator.SetFloat("LastVertical", y);
        }

        transform.Translate(moveDelta.x * Time.deltaTime, moveDelta.y * Time.deltaTime, 0);
    }

    public bool GetIsBat()
    {
        return isBat;
    }

    public bool GetAtHome()
    {
        return atHome;
    }

    private void CalculateBatSpawnPosition()
    {
        batSpawnPosition = transform.position;
        batSpawnPosition.y -= 0.85f;
        batSpawnPosition.y = Math.Min(batSpawnPosition.y, 1);
        batSpawnPosition.y = Math.Max(batSpawnPosition.y, -1);
        //henchmanLine = (int)batSpawnPosition.y;
    }

    private void GetLineForSpawnBat()
    {
        if (transform.position.y > -1.4 && transform.position.y < 1.4)
        {
            henchmanLine = (int)System.Math.Round(transform.position.y);
        }
        else henchmanLine = 0;
    }
    private void SpawnBat()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameStats.Henchman >= 3 )
        {
            GetLineForSpawnBat();
            if (GameStats.henchmanOnScreen[henchmanLine] == 0)
            {
                isTurning = true;
                animator.Play("InvokeHenchman");
                Invoke(nameof(SetCharacterSettings), 0.2f);
                CalculateBatSpawnPosition();
                Instantiate(Bat, batSpawnPosition, Quaternion.identity);
                GameStats.Henchman -= 3;
                HenchmanRes.UpdateHenchman();
            }
        }
    }

    public void EnterMainBuilding()
    {
        atHome = true;
    }

    public void ExitMainBuilding()
    {
        atHome = false;

        if (!isBat && timeCycle.GetIsDay())
        {
            TurnIntoBat();
        }
    }

    private void InvokeCheatCode()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGod)
            {
                UnsetGodSettings();
            }
            else
            {
                SetGodSettings();
            }
        }
    }

    private void SubdueEnemy()
    {
        //if (Input.GetKey(KeyCode.T) && GameStats.Henchman >= 5 && thunderAbilityTimer <= 0)
        if (Input.GetKey(KeyCode.T) && GameStats.Henchman >= 5 && thunderAbilityTimer <= 0)
        {
            isTurning = true;
            animator.Play("Magic");
            Invoke(nameof(ThunderZoneActivate), animator.GetCurrentAnimatorClipInfo(0).Length);
            GameStats.Henchman -= 5;
            resources.UpdateHenchman();
            //thunderAbilityTimer = thunderAbilityPeriod;
        }
    }

    private void ThunderZoneActivate()
    {
        ThunderZone.BeatEnemy();
        SetCharacterSettings();
    }

    private void PlayWalkSound()
    {
        if (isWalking && !isBat && !isTurning)
        {//0 2.6
            if (transform.position.y > 0 && transform.position.y < 2.6)
                onTheWay = true;
            else onTheWay = false;

            if (atHome && !sIsPlaying[0])
            {
                //source.clip = walksounds[0];
                sIsPlaying = new bool[] { false, false, false };
                sIsPlaying[0] = true;
                source.Play();
            }
            else if (onTheWay && !atHome && !sIsPlaying[2])
            {
                //source.clip = walksounds[2];
                sIsPlaying = new bool[] { false, false, false };
                sIsPlaying[2] = true;
                source.Play();
            }
            else if (!onTheWay && !atHome && !sIsPlaying[1])
            {
                //source.clip = walksounds[1];
                sIsPlaying = new bool[] { false, false, false };
                sIsPlaying[1] = true;
                source.Play();
            }

            if (!soundIsPlaying)
            {
                soundIsPlaying = true;
                source.Play();
            }
        }
        else
        {
            source.Stop();
            soundIsPlaying = false;
            sIsPlaying = new bool[] { false, false, false };
        }
    }

    public void SetOnTheWay(bool p) => onTheWay = p;
    public bool[] GetSIsPlaying() => sIsPlaying;
}
