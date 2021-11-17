using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatCotroller : Bat
{
    //Rigidbody2D bat;
    SpawnerScript ss;

    //public Transform enemy;
    //public float speed = 1.2f;

    private bool batForEnemy = false;

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
            if(nearEnemy.transform.position.y<transform.position.y)
                batt.velocity = new Vector2( -speed, -speed);
            else batt.velocity = new Vector2( -speed, speed);
        }
        else
        {
            if (nearEnemy.transform.position.y < transform.position.y)
                batt.velocity = new Vector2(speed, -speed);
            else batt.velocity = new Vector2(speed, speed);
        }
    }
}
