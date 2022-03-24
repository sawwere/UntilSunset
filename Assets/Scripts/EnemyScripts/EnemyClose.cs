using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClose : EnemyCharacter
{
    public Animator animator;

    public override void DoDamage(IDamage obj)
    {
        hitTimer -= Time.deltaTime;
        
        
        
        if (obj != null)
        {
            if (hitTimer <= 0)
            {
                obj.RecieveDamage(damage);
                hitTimer = hitPeriod;
            }
            else if ((hitTimer <= 2f && !(obj is Bat bat)) || hitTimer <= 1f)
            {
                animator.Play("Hit");
            }
        }
    }

    public override void ChangeAnimationToWalk()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            animator.Play("Movement");
    }

    public override void ChangeAnimationToIdle()
    {
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            animator.Play("Movement");
    }

}
