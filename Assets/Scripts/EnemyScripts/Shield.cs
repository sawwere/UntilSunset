using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IDamage
{
    EnemyShield parentEnemy;

    [SerializeField] private int maxHealth = 60; //макс здоровье
    protected float immunityPeriod = 2.0f; // переодичность получения урона
    private int currentHealth; //текущее здоровье
    public float immunityTimer; //таймер иммунитета к получению урона

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
            currentHealth -= amount;
            if (currentHealth <= 0)
                Destroy(gameObject);
            immunityTimer = immunityPeriod;
        }
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
