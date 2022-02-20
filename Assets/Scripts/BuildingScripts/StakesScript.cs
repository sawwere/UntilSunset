using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakesScript : Building
{
    private BuildPlace_1 bp;

    protected override void Start()
    {
        bp = transform.parent.GetComponent<BuildPlace_1>();
        bp.GetComponent<BoxCollider2D>().enabled = false;
        maxHealth = 3;
        base.Start();
    }

    public void OnDestroy()
    {
        bp.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void DoDamage(IDamage obj)
    {
        obj.RecieveDamage(1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyCharacter e = col.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
        {
            DoDamage(e);
            RecieveDamage(1);
        }
    }
}
