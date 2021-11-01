using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_1 : Wall
{
    protected override void Start()
    {
        maxHealth = 2;
        base.Start();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
            e.RecieveDamage(1);
    }
    public void RecieveDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("wall has been destoyed");
        }
    }
}
