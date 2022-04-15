using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wall_2 : Wall
{
    protected override void Start()
    {
        rep_wood_cost = 1;
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
}
