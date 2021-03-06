using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wall_2 : Wall, IDamage
{
    protected override void Start()
    {
        rep_wood_cost = 2;
        rep_stone_cost = 0;
        upg_wall_cost = 0;
        upg_stone_cost = 2;
        del_wood_re = 2;
        del_stone_re = 0;
        HideDialog();
        dialogBox.SetActive(false);
        maxHealth = 40;
        base.Start();
        source.PlayOneShot(CUpgrade, 0.5f);
    }

    public void DoDamage(IDamage obj)
    {
        obj.RecieveDamage(11, DamageType.wall);
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
