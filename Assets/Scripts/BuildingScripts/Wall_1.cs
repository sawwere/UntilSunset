using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_1 : Wall
{
    protected override void Start()
    {
        if (tag == "Wall1")
        {
            maxHealth = 2;
        }
        if (tag == "Wall2")
        {
            maxHealth = 4;
        }
        base.Start();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
            DoDamage(e);
    }
    
}
