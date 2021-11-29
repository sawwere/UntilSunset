using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xSpeed = 2.5f; // скорость
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

    private Resources resources;

    private void Awake()
    {
        rigidbBody2D = GetComponent<Rigidbody2D>();
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycle>();
    }

    private void Start()
    {
        animator.SetFloat("LastVertical", -1);
        isBat = false;
        atHome = true;
    }

    private void Update()
    {
        if (isTurning) return;

        Turning();

        SpawnBat();
    }

    void FixedUpdate()
    {
        if (isTurning) return;

        UpdateMotor();
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

    private void SpawnBat() // Вызов приспешника
    {
        if (Input.GetKeyDown(KeyCode.E) && GameStats.Henchman >= 1 && !isBat)
        {
            isTurning = true;
            animator.Play("InvokeHenchman");
            Invoke(nameof(SetCharacterSettings), 0.2f);
            GameStats.Henchman -= 1;
            resources.UpdateCoins();
            Instantiate(Bat, transform.position, Quaternion.identity);
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
}
