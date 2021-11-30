using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_2 : Wall
{

    private BuildPlace_1 bp;

    protected override void Start()
    {
        bp = transform.parent.GetComponent<BuildPlace_1>();
        maxHealth = 4;
        base.Start();
    }

    public void OnDestroy()
    {
        bp.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
            DoDamage(e);
    }
}
