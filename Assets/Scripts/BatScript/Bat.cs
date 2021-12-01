using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour, IDamage
{
    public float speed = 1.2f;
    Vector2 position;
    public int line;

    [SerializeField] private int maxHealth = 2; //максимальное здоровье
    public int damage = 1; //урон
    protected float immunityPeriod = 1.0f; // периодичность получения урона
    protected float hitPeriod = 5.0f; // периодичность нанесения урона
    protected int currentHealth; //текущее здоровье
    public float immunityTimer; //счетчик неуязвимости
    protected float hitTimer; //счетчик времени нанесения урона
    public float firstHitPeriod = 1.5f; // время до первого нанесения урона

    float smoothTime = 0.3f;

    protected Rigidbody2D batt;

    public GameObject cofiin;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, (float)System.Math.Round(transform.position.y));
        line = (int)System.Math.Round(transform.position.y);
        
        batt = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        immunityTimer = 0;
        hitTimer = firstHitPeriod;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStats.enemyOnScreen[line + 1].Count > 0)
            FindEnemy();
        else GoHome();
        if (immunityTimer > 0)
        {
            immunityTimer -= Time.deltaTime;
        }

        /*position = rb2d.position;
        position.x = position.x - Time.deltaTime*  speed ;
        rb2d.MovePosition(position);
        if (position.x < -12)
            Destroy(gameObject);*/
    }

    public void FindEnemy()
    {

        List<EnemyCharacter> listOfEnemies = GameStats.enemyOnScreen[line+1];
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
       // Vector2 vc = new Vector2(nearEnemy.transform.position.x, nearEnemy.transform.position.y);
        //batt.transform.Translate(Vector3.forward * Time.deltaTime);
        
        batt.position = Vector2.Lerp(batt.position, nearEnemy.transform.position,speed *Time.deltaTime);

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
        batt.position = Vector2.Lerp(batt.position,cofiin.transform.position, speed * Time.deltaTime);
    }

    public int GetLine()
    {
        return line;
    }
}
