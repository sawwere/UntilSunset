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
        maxHealth = 10;
        base.Start();
    }

    public void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        bp.BrokenStakes();
    }

    private IEnumerator StartDamage(EnemyCharacter e)
    {
        animator.Play("Attack");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length - 0.35f);

        if (!(e is EnemyKamikadze kamikadze))
            DoDamage(e);
        
        RecieveDamage(5);
    }

    public void DoDamage(EnemyCharacter e)
    {
        e.RecieveDamage(5);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        e = col.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
        {
            //Debug.Log(health);
            StartCoroutine(StartDamage(e));
        }
    }
}
