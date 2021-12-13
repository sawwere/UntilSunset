using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xSpeed = 2.5f;
    public float ySpeed = 2f;

    public float timeInvincible = 2.0f; // время неуязвимости

    public Rigidbody2D rigidbBody2D;
    Vector2 moveDelta;

    public Animator animator;

    private bool isBat;
    private bool isTurning;
    private bool atHome;

    private TimeCycle timeCycle;

    public GameObject Bat;

    private Resources HenchmanRes;
    private Resources coinsRes;

    private int sotringOrderBase = 1000;
    private Renderer myRenderer;
    private float offset = 0.0f;

    private float positionRendererTimer;
    private float positionRendererTimerMax = .1f;

    private Vector3 batSpawnPosition;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
        rigidbBody2D = GetComponent<Rigidbody2D>();
        HenchmanRes = GameObject.Find("HenchmenText").GetComponent<Resources>();
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycle>();
        coinsRes = GameObject.Find("CoinsText").GetComponent<Resources>();
    }

    private void Start()
    {
        animator.SetFloat("LastVertical", -1);
        isBat = false;
        atHome = true;
    }

    private void Update()
    {
        IncreaseMoney();

        if (isTurning) return;

        Turning();

        SpawnBat();
    }

    void FixedUpdate()
    {
        if (isTurning) return;

        UpdateMotor();
    }

    private void LateUpdate()
    {
        positionRendererTimer -= Time.deltaTime;
        if (positionRendererTimer <= 0f)
        {
            positionRendererTimer = positionRendererTimerMax;
            myRenderer.sortingOrder = (int)(sotringOrderBase - transform.position.y * 10 - offset);
        }
    }

    private void Turning() // Превращение в мышь (из мыши)
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
        animator.Play("ToBat");
        Invoke(nameof(SetBatSettings), 0.5f);
    }

    private void TurnIntoCharacter()
    {
        isTurning = true;
        animator.Play("ToCharacter");
        Invoke(nameof(SetCharacterSettings), 0.5f);
    }

    private void SetBatSettings() // Установка характеристик мыши
    {
        animator.Play("Bat");
        isTurning = false;
        isBat = true;
        offset = 5f;
        xSpeed = 10f;
        ySpeed = 8f;
    }

    private void SetCharacterSettings() // Установка характеристик персонажа
    {
        animator.SetFloat("LastHorizontal", 0);
        animator.SetFloat("LastVertical", -1);
        animator.Play("Idle");
        isTurning = false;
        isBat = false;
        offset = 0f;
        xSpeed = 2.5f;
        ySpeed = 2f;
    }

    private void UpdateMotor() // Движение игрока
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

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
    }

    private void SpawnBat() // Вызов приспешника
    {
        if (Input.GetKeyDown(KeyCode.E) && GameStats.Henchman > 0 && !isBat && timeCycle.GetIsDay())
        {
            isTurning = true;
            animator.Play("InvokeHenchman");
            Invoke(nameof(SetCharacterSettings), 0.2f);
            CalculateBatSpawnPosition();
            Instantiate(Bat, batSpawnPosition, Quaternion.identity);
            GameStats.Henchman--;
            HenchmanRes.UpdateHenchman();
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

    private void IncreaseMoney()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameStats.Coins += 100;
            coinsRes.UpdateCoins();
        }
    }
}
