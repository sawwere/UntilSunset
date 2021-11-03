using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClose : EnemyCharacter
{
    public void DoDamage(Collider2D collision)
    {
        Building b = collision.GetComponent<Building>();
        if (b != null)
        {
            if (hitTimer <= 0)
            {
                b.RecieveDamage(this.damage);
            }
            hitTimer = hitPeriod;
        }
    }
}
