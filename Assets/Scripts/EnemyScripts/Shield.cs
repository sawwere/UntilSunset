using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IDamage
{
    EnemyShield parentEnemy;

    [SerializeField] private int maxHealth = 40; //���� ��������
    protected float immunityPeriod = 2.0f; // ������������� ��������� �����
    private int currentHealth; //������� ��������
    public float immunityTimer; //������ ���������� � ��������� �����

    public int health
    {
        get { return currentHealth; }
        protected set { currentHealth = value; }
    }

    void Start()
    {
        parentEnemy = transform.parent.gameObject.GetComponent<EnemyShield>();
        currentHealth = maxHealth;
        immunityTimer = 0;
    }

    void Update()
    {
        if (immunityTimer > 0)
        {
            immunityTimer -= Time.deltaTime;
        }
    }

    public void DoDamage(IDamage obj)
    {
        return;
    }

    public int GetLine()
    {
        return parentEnemy.GetLine();
    }

    public void RecieveDamage(int amount)
    {
        if (immunityTimer <= 0)
        {
            Debug.Log(currentHealth);
            currentHealth -= amount;
            if (currentHealth <= 0)
                Destroy(gameObject);
            immunityTimer = immunityPeriod;
        }
    }
}
