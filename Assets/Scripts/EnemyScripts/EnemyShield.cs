using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : EnemyClose
{
    public Shield shield;

    protected override void Start()
    {
        //shield = transform.GetChild(1).GetComponent<Shield>();
        base.Start();
    }

    public  override void RecieveDamage(int amount)
    {
        if (shield)
        {
            shield.RecieveDamage(amount);
        }
        else
        {
            base.RecieveDamage(amount);
        }
    }
}
