using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyCharacter: MonoBehaviour, IDamage, IMovable
{
    public string _name; // имя
    public int price; // цена спавна(сложность врага)
    [SerializeField] private int maxHealth = 2; //макс здоровье
    [SerializeField] public float speed = 1.0f; //скорость передвижения
    protected float speedInit; // для восстановления скорости после остановки
    public int line; //на какой линни ходит враг
    public int armor = 0; //броня на будущее
    public int damage = 1; //урон
    protected float immunityPeriod = 2.0f; // переодичность получения урона
    protected float hitPeriod = 5.0f; // переодичность нанесения урона
    protected int _direction = 1; //направление
    private int currentHealth; //текущее здоровье
    public float immunityTimer; //таймер иммунитета к получению урона
    protected float hitTimer; //таймер нанесения урона
    public float firstHitPeriod = 1.5f; // ����� �� ������� ��������� �����

    private bool enterMainBuilding = false;

    public LayerMask aviableHitMask;

    public GameObject coffin;

    protected Rigidbody2D rigidbody2d;
    [SerializeField] private GameObject resoursePrefab; // какой ресурс может выпасть с врага

    public int health 
    { 
        get { return currentHealth; } 
        protected set { currentHealth = value; }
    }

    public int direction
    {
        get { return _direction;}
        set { if (System.Math.Abs(value) == 1) _direction = value; }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SpeedResetToZero()
    {
        speedInit = speed;
        speed = 0;
    }

    public void SpeedRestore()
    {
        speed = speedInit;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        speedInit = speed;
        line = (int)transform.position.y;
        GameStats.enemyOnScreen[line+1].Add(this);
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        immunityTimer = 0;
        hitTimer = firstHitPeriod;
        transform.localScale = new Vector3(transform.localScale.x * direction, transform.localScale.y, transform.localScale.x);
        coffin = GameObject.FindWithTag("Coffin");
        aviableHitMask = LayerMask.GetMask("Buildings") | LayerMask.GetMask("NPC_Friend");
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

        {
            position.x = position.x + Time.deltaTime * speed * direction;
            rigidbody2d.MovePosition(position);

        }
        //Debug.Log(speed);
        if (transform.position.y > 2 || transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy() 
    {
        GameStats.enemyOnScreen[line+1].Remove(this);
    }

    //вызывается при убийстве врага
    public void EnemyKilled()
    {
        if (Random.Range(0, 2) > 0 || this._name=="enemy1_range" || this._name == "enemy1_big")
            Instantiate(resoursePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Destroy(gameObject);
    }

    virtual public void RecieveDamage(int amount)
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

    //нанесение урона базе игрока и самоуничтожение
    public void EnterMainBuilding()
    {
        enterMainBuilding = true;
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        coffin.GetComponent<Coffin>().RecieveDamage(damage);
        Destroy(gameObject);
    }

    //инициирует отступление
    public void ReturnToBase()
    {
        direction = transform.position.x < 0 ? -1 : 1;
        SpeedRestore();
        PlayWalkAnimation();
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.x);
    }

    public virtual void PlayWalkAnimation()
    {
        return;
    }


    public int GetLine() 
    {
        return this.line;
    }

    //делает этого врага союзником игрока
    //разворачивает в обратном направлении и заставляет атаковать других врагов
    public void BecomeFriend()
    {
        ReturnToBase();
        aviableHitMask = LayerMask.GetMask("NPC");
        //Debug.Log(aviableHitMask.value);
        gameObject.layer = LayerMask.NameToLayer("NPC_Friend");
        transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("NPC_Friend");
        GameStats.enemyOnScreen[line + 1].Remove(this);
    }
}
