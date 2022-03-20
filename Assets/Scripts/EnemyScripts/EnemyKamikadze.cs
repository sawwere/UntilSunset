using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikadze : EnemyClose
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        aviableHitMask = base.aviableHitMask | LayerMask.GetMask("NPC");
    }

    void BlowUp()
    {
        
    }

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
}
