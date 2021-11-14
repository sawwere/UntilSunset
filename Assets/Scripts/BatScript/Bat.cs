using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public int mHealth = 1;
    public float speed = 1.2f;
    //BatCotroller batcntr;
    Vector2 position;
    //protected int currentHealth;

    private bool batForEnemy = false;

    public SpawnerScript ss;

    protected Rigidbody2D batt;
    // Start is called before the first frame update
    void Start()
    {
        batt = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ss.enemyOnScreen != null)
            Poisk();


        /*position = rb2d.position;
        position.x = position.x - Time.deltaTime*  speed ;
        rb2d.MovePosition(position);
        if (position.x < -12)
            Destroy(gameObject);*/
    }

    public void Poisk()
    {
        batForEnemy = true;
        List<EnemyCharacter> listOfEnemi = ss.enemyOnScreen;
        float distancetoEnemy;
        EnemyCharacter nearEnemy = null;
        float minDistance = float.MaxValue;
        for (int i = 0; i < listOfEnemi.Count; i++)
        {
            distancetoEnemy = Vector2.Distance(transform.position, listOfEnemi[i].transform.position);
            if (minDistance > distancetoEnemy)
            {
                minDistance = distancetoEnemy;
                nearEnemy = listOfEnemi[i];
            }
        }

        EnterBat(minDistance, nearEnemy);

    }

    void EnterBat(float minDistance, EnemyCharacter nearEnemy)
    {
        if (nearEnemy.transform.position.x < transform.position.x)
        {
            if (nearEnemy.transform.position.y < transform.position.y)
                batt.velocity = new Vector2(-speed, -speed);
            else batt.velocity = new Vector2(-speed, speed);
        }
        else
        {
            if (nearEnemy.transform.position.y < transform.position.y)
                batt.velocity = new Vector2(speed, -speed);
            else batt.velocity = new Vector2(speed, speed);
        }
    }
}
