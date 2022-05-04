using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour, IDamage, IMovable
{
    public float speed = 2f;
    public float speedInit;
    public int line = PlayerController.henchmanLine;
    private int direction = 0;

    [SerializeField] private int maxHealth = 30; //макс здоровье
    public int damage = 10; //урон
    protected float immunityPeriod = 2.0f; // переодичность получения урона
    protected float hitPeriod = 4.0f; // переодичность нанесения урона
    protected int currentHealth; //текущее здоровье
    public float immunityTimer; //таймер иммунитета к получению урона
    protected float hitTimer; //таймер нанесения урона
    public float firstHitPeriod = 1.5f; // ����� �� ������� ��������� �����

    protected Rigidbody2D batt;

    public GameObject cofiin;

    private TimeCycle timeCycle;
    private Resources HenchmanRes;

    public LayerMask aviableHitMask;

    public GameObject BloodParticles;
    private Vector3 ParticlesSpawnPosition;

    private Transform playerPos;
    private AudioSource source;
    public AudioClip[] CDeaths;
    private const float MINVOL = 0.01f;
    private const float MAXVOL = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        speedInit = speed;
        transform.position = new Vector2(transform.position.x, (float)System.Math.Round(transform.position.y));
        if(transform.position.y>-1.4 && transform.position.y<1.4)
        {
            line = (int)(transform.position.y);
        }
        else line = 0;
       //line = PlayerController.henchmanline;
        
        batt = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        immunityTimer = immunityPeriod;
        hitTimer = 0;
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycle>();
        HenchmanRes = GameObject.Find("HenchmenText").GetComponent<Resources>();
        aviableHitMask = LayerMask.GetMask("NPC");
        source = GetComponent<AudioSource>();
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStats.enemyOnScreen[line + 1].Count > 0)
        {
            if (timeCycle.GetIsDay())
                FindEnemy();
            else GoHome();
        }
        else GoHome();


        if (immunityTimer > 0)
        {
            immunityTimer -= Time.deltaTime;
        }

        SetSoundParams();
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
        GameStats.henchmanOnScreen[line+1] = 1;
        direction = (int)nearEnemy.transform.position.x > transform.position.x ? 1 : -1;
        batt.position = Vector3.MoveTowards(batt.position, nearEnemy.transform.position, speed * Time.deltaTime);
    }

    public void DoDamage(IDamage obj)
    {
        hitTimer -= Time.deltaTime;
        if (obj != null)
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
            CalculateParticlesPosition();
            Instantiate(BloodParticles, ParticlesSpawnPosition, Quaternion.identity);
            Debug.Log(currentHealth);
            currentHealth -= amount;
            transform.GetChild(0).GetComponent<UIHenchmen>().SetValue(currentHealth / (float)maxHealth);
            if (currentHealth <= 0)
            {
                GameStats.henchmanOnScreen[line + 1] = 0;
                GameObject.Find("ResSounds").GetComponent<AudioSource>().PlayOneShot(CDeaths[Random.Range(0, CDeaths.Length)], 0.8f);
                Destroy(gameObject);
            }
            immunityTimer = immunityPeriod;
        }
    }

    private void CalculateParticlesPosition()
    {
        ParticlesSpawnPosition = transform.position;
        ParticlesSpawnPosition.y += 0.5f;
    }

    void GoHome()
    {
        //batt.position = Vector2.Lerp(batt.position,cofiin.transform.position, speed * Time.deltaTime);
        Vector3 v3 = new Vector3(cofiin.transform.position.x, cofiin.transform.position.y+line, cofiin.transform.position.z);
        batt.position = Vector3.MoveTowards(batt.position, v3, speed * Time.deltaTime);
        if (!timeCycle.GetIsDay())
        {
            ReturnToPocket();
        }
    }

    void ReturnToPocket()
    {
        if(batt.position.x == cofiin.transform.position.x) //&& batt.position.y == cofiin.transform.position.y)
        {
            GameStats.Henchman+=1;
            GameStats.henchmanOnScreen[line + 1] = 0;
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

    void OnDestroy()
    {
        GameStats.henchmanOnScreen[line + 1] = 0;
    }

    public int GetLine()
    {
        return line;
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
        speed = 0.0001f;
    }

    public void SpeedRestore()
    {
        speed = speedInit;
    }

    private void SetSoundParams()
    {
        float posDelta = gameObject.transform.position.x - playerPos.position.x;
        if (Mathf.Abs(posDelta) >= 28)
        {
            source.panStereo = Mathf.Sign(posDelta);
            source.volume = MINVOL;
        }
        else
        {
            source.panStereo = posDelta / 28;
            source.volume = Mathf.Max(MINVOL, MAXVOL - Mathf.Abs(posDelta) / (28 / MAXVOL));
        }
    }

    public void PauseFlappingSound()
    {
        source.loop = false;
        source.Pause();
    }

    public void ContinueFlappingSound()
    {
        source.loop = true;
        source.Play();
    }
}
