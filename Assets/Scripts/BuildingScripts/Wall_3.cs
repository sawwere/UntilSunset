using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wall_3 : Wall
{

    protected override void Start()
    {
        rep_wood_cost = 0;
        rep_stone_cost = 1;
        del_wood_re = 1;
        del_stone_re = 1;
        HideDialog();
        dialogBox.SetActive(false);
        maxHealth = 60;
        base.Start();
        source.PlayOneShot(CUpgrade, 0.5f);
    }

}
