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

    public  override void RecieveDamage(int amount, DamageType damageType)
    {
        if (shield && damageType != DamageType.stakes)
        {
            shield.RecieveDamage(amount, damageType);
        }
        else
        {
            base.RecieveDamage(amount, damageType);
        }
        UpdateHpBar(health + shield.health, GetMaxHealth() + shield.GetMaxHealth());
    }
}
