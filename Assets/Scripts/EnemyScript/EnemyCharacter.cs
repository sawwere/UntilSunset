using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyCharacter: MonoBehaviour
{
    public string _name; // имя
    public int maxHealth = 2; //здоровье
    public float speed = 1.0f; //скорость движения
    public int armor = 0; //броня
    public int damage = 1; //урон
    public float immunityPeriod = 2.0f; // периодичность получения урона
    public float hitPeriod = 5.0f; // периодичность нанесения урона
    protected int direction = 1; //направление
    protected int currentHealth; //текущее здоровье
    public float immunityTimer; //счетчик неуязвимости
    protected float hitTimer; //счетчик времени нанесения урона

    public LayerMask aviableHitMask;

    protected Rigidbody2D rigidbody2d;

    public int health 
    { 
        get { return currentHealth; } 
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        immunityTimer = 0;
        hitTimer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + Time.deltaTime * speed * direction;
        rigidbody2d.MovePosition(position);
    }

    public void RecieveDamage(int amount)
    {
        if (immunityTimer <= 0)
        {
            currentHealth -= amount;
            immunityTimer = immunityPeriod;
            if (currentHealth <= 0)
                Destroy(gameObject);
        }
        else
        {
            immunityTimer -= Time.deltaTime;
        }
    }
}
