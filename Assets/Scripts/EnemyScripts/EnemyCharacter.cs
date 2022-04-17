using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

[System.Serializable]
public class EnemyCharacter: MonoBehaviour, IDamage, IMovable
{
    public string _name; // имя
    public int price; // цена спавна(сложность врага)
    [SerializeField] private int maxHealth = 2; //макс здоровье
    [SerializeField] public float speed = 1.0f; //скорость передвижения
    protected float speedInit; // для восстановления скорости после остановки
    private int line; //на какой линни ходит враг
    public int damage = 1; //урон
    public float immunityPeriod = 2.0f; // переодичность получения урона
    public float hitPeriod = 5.0f; // переодичность нанесения урона
    [SerializeField] protected int _direction = 1; //направление
    private int currentHealth; //текущее здоровье
    public float immunityTimer; //таймер иммунитета к получению урона
    protected float hitTimer; //таймер нанесения урона
    public float firstHitPeriod = 1.5f; // ����� �� ������� ��������� �����

    public LayerMask aviableHitMask; // store layers where objects can be damaged
    protected bool isFriend;

    public GameObject BloodParticles;
    public GameObject MagicParticles;
    private Vector3 ParticlesSpawnPosition;

    protected float fixDeltaTimer = 0.1f;

    private float oldX = 0f;
    private float newX = 0f;

    public GameObject skull = null;

    public AudioSource source;
    public AudioClip walkSound;

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
        return speed * direction;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SpeedResetToZero()
    {
        //speedInit = speed;
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
        line = (int)System.Math.Round(transform.position.y);
        GameStats.enemyOnScreen[line+1].Add(this);
        rigidbody2d = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        immunityTimer = 0;
        hitTimer = firstHitPeriod;
        transform.localScale = new Vector3(transform.localScale.x * direction, transform.localScale.y, transform.localScale.x);
        aviableHitMask = LayerMask.GetMask("Buildings") | LayerMask.GetMask("NPC_Friend");
        isFriend = false;
        source.volume = 0.05f;
        source.loop = true;
        source.clip = walkSound;
        ChangeAnimationToIdle();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (immunityTimer > 0)
        {
            immunityTimer -= Time.deltaTime;
        }
        if (fixDeltaTimer > 0)
        {
            fixDeltaTimer -= Time.deltaTime;
        }
        else
        {
            oldX = newX;// ВРОДЕ ТУТ СДЕЛАТЬ ЗВУКИ ХОДЬБЫ НАДО (для себя)
            newX = transform.position.x;
            if (Abs(newX - oldX) >= 0.05f)
            {
                ChangeAnimationToWalk();
                if (!source.isPlaying) source.Play();
            }
            else
            {
                ChangeAnimationToIdle();
                if (source.isPlaying) source.Stop();
            }
            fixDeltaTimer = 0.2f;
        }
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
        Instantiate(resoursePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Destroy(gameObject);
    }

    virtual public void RecieveDamage(int amount)
    {
        if (immunityTimer <= 0)
        {
            CalculateParticlesPosition();
            Instantiate(BloodParticles, ParticlesSpawnPosition, Quaternion.identity);

            currentHealth -= amount;
            if (currentHealth <= 0)
                EnemyKilled();
            immunityTimer = immunityPeriod;
        }
    }

    private void CalculateParticlesPosition()
    {
        ParticlesSpawnPosition = transform.position;
        ParticlesSpawnPosition.y += 0.85f;
    }

    public virtual void DoDamage(IDamage obj)
    {
        return; // заглушка
    }

    //нанесение урона базе игрока и самоуничтожение
    public void EnterMainBuilding()
    {
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        Destroy(gameObject);
    }

    //инициирует отступление
    public virtual void ReturnToBase()
    {
        direction = transform.position.x < 0 ? -1 : 1;
        SpeedRestore();
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.x);
    }

    public virtual void ChangeAnimationToWalk()
    {
        return;
    }
    
    public virtual void ChangeAnimationToIdle()
    {
        return;
    }

    public int GetLine() 
    {
        return this.line;
    }

    public bool IsFriend()
    {
        return isFriend;
    }

    //делает этого врага союзником игрока
    //разворачивает в обратном направлении и заставляет атаковать других врагов
    public void BecomeFriend()
    {
        ReturnToBase();
        hitTimer = 1f;
        CalculateParticlesPosition();
        Instantiate(MagicParticles, ParticlesSpawnPosition, Quaternion.identity);
        skull.SetActive(true);
        aviableHitMask = LayerMask.GetMask("NPC");
        gameObject.layer = LayerMask.NameToLayer("NPC_Friend");
        gameObject.tag = "Friend";
        transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("NPC_Friend");
        GameStats.enemyOnScreen[line + 1].Remove(this);
    }

    public void IsFriendMakeTrue()
    {
        isFriend = true;
    }

    public void PauseWalkSound() => source.Pause();
    public void ContinueWalkSound() => source.Play();
}
