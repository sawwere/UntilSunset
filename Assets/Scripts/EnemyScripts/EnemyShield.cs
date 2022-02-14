using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : EnemyClose
{
    bool haveShield;
    Shield shield;

    protected override void Start()
    {
        haveShield = true;
        shield = transform.GetChild(1).GetComponent<Shield>();
        base.Start();
    }

    public  override void RecieveDamage(int amount)
    {
        if (haveShield)
        {
            shield.RecieveDamage(amount);
        }
        else
        {
            base.RecieveDamage(amount);
        }
    }
}
