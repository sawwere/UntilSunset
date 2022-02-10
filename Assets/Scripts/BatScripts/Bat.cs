using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour, IDamage
{
    public float speed = 2.5f;
    public float speedInit;
    Vector2 position;
    public int line;

    [SerializeField] private int maxHealth = 2; //макс здоровье
    public int damage = 1; //урон
    protected float immunityPeriod = 1.0f; // переодичность получения урона
    protected float hitPeriod = 5.0f; // переодичность нанесения урона
    protected int currentHealth; //текущее здоровье
    public float immunityTimer; //таймер иммунитета к получению урона
    protected float hitTimer; //таймер нанесения урона
    public float firstHitPeriod = 1.5f; // ����� �� ������� ��������� �����

    protected Rigidbody2D batt;

    public GameObject cofiin;

    private TimeCycle timeCycle;
    private Resources HenchmanRes;
    // Start is called before the first frame update
    void Start()
    {
        speedInit = speed;
        transform.position = new Vector2(transform.position.x, (float)System.Math.Round(transform.position.y));
        if(transform.position.y>-1.4 && transform.position.y<1.4)
        {
            line = (int)System.Math.Round(transform.position.y);
        }
        else line = 0;
        
        batt = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        immunityTimer = 0;
        hitTimer = firstHitPeriod;
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycle>();
        HenchmanRes = GameObject.Find("HenchmenText").GetComponent<Resources>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStats.enemyOnScreen[line + 1].Count > 0)
        {
            if (timeCycle.GetIsDay())
                FindEnemy();
            else  GoHome(); 

        }     
        else GoHome();

        if (immunityTimer > 0)
        {
            immunityTimer -= Time.deltaTime;
        }
    }

    public void FindEnemy()
    {
        List<EnemyCharacter> listOfEnemies = GameStats.enemyOnScreen[line + 1];
        float distancetoEnemy;
        EnemyCharacter nearEnemy = null;
        float minDistance = float.MaxValue;
        for (int i = 0; i < listOfEnemies.Count; i++)
        {
            distancetoEnemy = Vector2.Distance(transform.position, listOfEnemies[i].transform.position);
            if (minDistance > distancetoEnemy)
            {
                minDistance = distancetoEnemy;
                nearEnemy = listOfEnemies[i];
            }
        }

        if (nearEnemy)
            EnterBat(minDistance, nearEnemy);


    }

    void EnterBat(float minDistance, EnemyCharacter nearEnemy)
    {
        /*if (nearEnemy.transform.position.x < transform.position.x)
        {
            if (nearEnemy.transform.position.y < transform.position.y)
                batt.velocity = new Vector2(-speed , -speed ) ;
            else batt.velocity = new Vector2(-speed , speed ) ;
        }
        else
        {
            if (nearEnemy.transform.position.y < transform.position.y)
                batt.velocity = new Vector2(speed , -speed) ;
            else batt.velocity = new Vector2(speed , speed) ;
        }*/
        //batt.position = Vector2.Lerp(batt.position, nearEnemy.transform.position,speed*Time.deltaTime);

        batt.position = Vector3.MoveTowards(batt.position, nearEnemy.transform.position, speed * Time.deltaTime);
    }

    public void DoDamage(IDamage obj)
    {
        hitTimer -= Time.deltaTime;
        if ((obj != null) && (!obj.Equals(typeof(Bat))))
        {
             if (hitTimer <= 0)
             {
                 obj.RecieveDamage(damage);
                 hitTimer = hitPeriod;
             }
        }
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

    void GoHome()
    {
        //batt.position = Vector2.Lerp(batt.position,cofiin.transform.position, speed * Time.deltaTime);
        batt.position = Vector3.MoveTowards(batt.position, cofiin.transform.position, speed * Time.deltaTime);
        if (!timeCycle.GetIsDay())
        {
            ReturnToPocket();
        }
    }

    public int GetLine()
    {
        return line;
    }

    void ReturnToPocket()
    {
        if(batt.position.x == cofiin.transform.position.x && batt.position.y == cofiin.transform.position.y)
        {
            GameStats.Henchman+=1;
            Destroy(gameObject);
            HenchmanRes.UpdateHenchman();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            speed = 0;
            //Debug.Log("OnCollisionEnter2D BAT");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            speed = speedInit;
            //Debug.Log("OnCollisionExit2D BAT");
        }
    }
}
