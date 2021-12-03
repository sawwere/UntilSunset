using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClose : EnemyCharacter
{
    public Animator animator;

    new public void DoDamage(IDamage obj)
    {
        hitTimer -= Time.deltaTime;
        
        if (obj != null)
        {
            if (hitTimer <= 0)
            {
                obj.RecieveDamage(damage);
                hitTimer = hitPeriod;
            }
            else if (hitTimer <= 1.25f)
            {
                animator.Play("Hit");
            }
            else animator.Play("Idle");
        }
    }

    public override void PlayWalkAnimation()
    {
        animator.Play("Movement");
    }
}
