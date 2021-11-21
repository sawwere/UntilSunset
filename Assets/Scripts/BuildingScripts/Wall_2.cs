using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_2 : Wall
{
    protected override void Start()
    {
        maxHealth = 4;
        base.Start();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
            DoDamage(e);
    }
}
