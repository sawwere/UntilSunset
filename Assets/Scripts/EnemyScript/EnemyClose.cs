using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClose : EnemyCharacter
{
    public void DoDamage(Collider2D collision)
    {
        Wall_1 wall = collision.GetComponent<Wall_1>();
        if (wall != null)
        {
            if (hitTimer <= 0)
            {
                wall.RecieveDamage(this.damage);
                hitTimer = hitPeriod;
            }
            else
            {
                hitTimer -= Time.deltaTime;
            }

        }
    }
}
