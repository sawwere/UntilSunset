using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyCharacter: MonoBehaviour, IDamage
{
    public string _name; // имя
    public int price; // условная стоимость спавна
    [SerializeField] private int maxHealth = 2; //максимальное здоровье
    public float speed = 1.0f; //скорость движения
    public int line;
    public int armor = 0; //броня
    public int damage = 1; //урон
    protected float immunityPeriod = 2.0f; // периодичность получения урона
    protected float hitPeriod = 5.0f; // периодичность нанесения урона
    protected int _direction = 1; //направление
    private int currentHealth; //текущее здоровье
    public float immunityTimer; //счетчик неуязвимости
    protected float hitTimer; //счетчик времени нанесения урона
    public float firstHitPeriod = 1.5f; // время до первого нанесения урона

    private bool enterMainBuilding = false;

    public LayerMask aviableHitMask;

    protected Rigidbody2D rigidbody2d;
    [SerializeField] private GameObject coinPrefab;

    public int health 
    { 
        get { return currentHealth; } 
    }

    public int direction
    {
        get { return _direction;}
        set { if (System.Math.Abs(value) == 1) _direction = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        line = (int)transform.position.y;
        GameStats.enemyOnScreen[line+1].Add(this);
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
            //position.y = position.y + Time.deltaTime * speed;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            rigidbody2d.MovePosition(position);

        }
        
        if (transform.position.y > 2 || transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy() 
    {
        GameStats.enemyOnScreen[line+1].Remove(this);
    }

    //если враг умер из-за потери всего здоровья
    public void EnemyKilled()
    {
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
        return; // заглушка
    }

    public void EnterMainBuilding()
    {
        enterMainBuilding = true;
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        Vector2 drctn = new Vector2(-transform.position.x, -transform.position.y);
        rigidbody2d.velocity = drctn.normalized * speed;
    }

    public void ReturnToBase()
    {
        direction *= -1;
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
    }
}
