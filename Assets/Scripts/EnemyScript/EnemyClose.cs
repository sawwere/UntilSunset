using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClose : EnemyCharacter
{
    public Animator animator;

    public void DoDamage(Collider2D collision)
    {
        hitTimer -= Time.deltaTime;
        //immunityTimer -= Time.deltaTime;

        Building b = collision.GetComponent<Building>();
        if (b != null)
        {
            if (hitTimer <= 0)
            {
                b.RecieveDamage(this.damage);

                hitTimer = hitPeriod;
            }
            else if (hitTimer <= 1.25f)
            {
                animator.Play("Hit");
            }
            else animator.Play("Idle");
        }
    }
}
