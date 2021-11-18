using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyCharacter: MonoBehaviour, IDamage
{
    public string _name; // ���
    public int price; // �������� ��������� ������
    [SerializeField] private int maxHealth = 2; //������������ ��������
    public float speed = 1.0f; //�������� ��������
    public int armor = 0; //�����
    public int damage = 1; //����
    protected float immunityPeriod = 2.0f; // ������������� ��������� �����
    protected float hitPeriod = 5.0f; // ������������� ��������� �����
    protected int direction = 1; //�����������
    private int currentHealth; //������� ��������
    public float immunityTimer; //������� ������������
    protected float hitTimer; //������� ������� ��������� �����
    public float firstHitPeriod = 1.5f; // ����� �� ������� ��������� �����

    private bool enterMainBuilding = false;

    public LayerMask aviableHitMask;

    protected Rigidbody2D rigidbody2d;
    [SerializeField] private GameObject coinPrefab;

    public int health 
    { 
        get { return currentHealth; } 
    }

    // Start is called before the first frame update
    void Start()
    {
        GameStats.enemyOnScreen.Add(this);
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        immunityTimer = 0;
        hitTimer = firstHitPeriod;
    }

    // Update is called once per frame
    private void Update()
    {
        if (immunityTimer > 0)
        {
            immunityTimer -= Time.deltaTime;
        }/*
        if (hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;
        }*/
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        if (enterMainBuilding)
        {
            position.y = position.y + Time.deltaTime * speed;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            
        }
        rigidbody2d.MovePosition(position);
        if (position.y > 2 || position.y < -1)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyKilled()
    {
        GameStats.enemyOnScreen.Remove(this);
        System.Random r = new System.Random();
        if (r.Next(2) > 0)
            Instantiate(coinPrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Destroy(gameObject);
    }

    public void RecieveDamage(int amount)
    {
        if (immunityTimer <= 0)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
                EnemyKilled();
            immunityTimer = immunityPeriod;
        }
    }

    public void DoDamage(IDamage obj)
    {
        return; // ��������
    }

    public void EnterMainBuilding()
    {
        enterMainBuilding = true;
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


}
