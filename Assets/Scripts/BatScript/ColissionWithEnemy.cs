using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColissionWithEnemy : MonoBehaviour
{
    public EnemyCharacter enemy;
    public Bat bat;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bamps");
        enemy.maxHealth--;
        bat.mHealth--;
            
    }
}
