using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wall_1 : Wall, IDamage
{

    protected override void Start()
    {
        rep_wood_cost = 1;
        rep_stone_cost = 0;
        upg_wall_cost = 2;
        upg_stone_cost = 0;
        del_wood_re = 1;
        del_stone_re = 0;
        dialogBox.SetActive(false);
        maxHealth = 20;
        base.Start();
    }

    public void DoDamage(IDamage obj)
    {
        obj.RecieveDamage(9, DamageType.wall);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
        {
            DoDamage(e);
        }
    }
}
