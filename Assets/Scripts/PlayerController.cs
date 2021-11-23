using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xSpeed = 2.5f; // ��������
    public float ySpeed = 2f;

    public float timeInvincible = 2.0f; // ����� ������������

    public Rigidbody2D rigidbBody2D;
    Vector2 moveDelta;

    public Animator animator;

    private bool isBat;
    private bool isTurning;

    public GameObject Bat;

    private Resources resources;

    private void Awake()
    {
        rigidbBody2D = GetComponent<Rigidbody2D>();
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
    }

    private void Start()
    {
        animator.SetFloat("LastVertical", -1);
        isBat = false;
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

    private void Turning() // ����������� � ���� (�� ����)
    {
        if (Input.GetButtonDown("Jump"))
        {
            isTurning = true;
            if (!isBat)
            {
                animator.Play("ToBat");
                Invoke(nameof(SetBatSettings), 0.5f);
            }
            else
            {
                animator.Play("ToCharacter");
                Invoke(nameof(SetCharacterSettings), 0.5f);
            }
        }
    }

    private void SetBatSettings() // ��������� ������������� ����
    {
        animator.Play("Bat");
        isTurning = false;
        isBat = true;
        xSpeed = 10f;
        ySpeed = 8f;
    }

    private void SetCharacterSettings() // ��������� ������������� ���������
    {
        animator.SetFloat("LastHorizontal", 0);
        animator.SetFloat("LastVertical", -1);
        animator.Play("Idle");
        isTurning = false;
        isBat = false;
        xSpeed = 2.5f;
        ySpeed = 2f;
    }

    private void UpdateMotor() // �������� ������
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

    public void SpawnBat() // ����� �����������
    {
        if (Input.GetKeyDown(KeyCode.E) && GameStats.Coins >= 1 && !isBat)
        {
            isTurning = true;
            animator.Play("InvokeHenchman");
            Invoke(nameof(SetCharacterSettings), 0.2f);
            GameStats.Coins -= 1;
            resources.UpdateCoins();
            Instantiate(Bat, transform.position, Quaternion.identity);
        }
    }
}
