using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakesScript : Building
{
    private BuildPlace_1 bp;

    public Animator animator;

    EnemyCharacter e;

    protected override void Start()
    {
        bp = transform.parent.GetComponent<BuildPlace_1>();
        bp.GetComponent<BoxCollider2D>().enabled = false;
        maxHealth = 15;
        base.Start();
    }

    public void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        bp.BrokenStakes();
    }

    private void StartDamage()
    {
        animator.Play("Attack");
        Invoke(nameof(DoDamage), animator.GetCurrentAnimatorClipInfo(0).Length - 0.35f);
    }

    public void DoDamage(EnemyCharacter obj)
    {
        obj.RecieveDamage(5);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        e = col.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
        {
            Debug.Log(health);
            StartDamage();
            DoDamage(e);
            RecieveDamage(5);
        }
    }
}
