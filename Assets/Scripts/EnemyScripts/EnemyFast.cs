using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFast : EnemyClose
{
    [SerializeField] private float speedIncrease = 1f;

    //bool gotHit;
    
    protected override void Start() 
    {
        //gotHit = false;
        base.Start();
    }
    public override void RecieveDamage(int amount, DamageType damageType)
    {
        
        base.RecieveDamage(amount, damageType);
    }

    private void IncreaseSpeed()
    {
        speed = speedIncrease;
        speedInit = speed;
    }
}
