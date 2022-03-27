using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallButton : MonoBehaviour
{
    private Wall wl;
    private GameObject upginfo;
    private Resources resources;

    public void Start()
    {
        wl = transform.parent.GetComponent<Wall>();
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
    }

    public void WallUpgButtonPressed()
    {
        wl.UpgradeWall();
    }

    public void WallRecoverButtonPressed()
    {
        wl.Recover();
    }

    public void WallDelButtonPressed()
    {
        wl.DestroyWall();
    }

    public void MouseEnterButtonUpg(Button b)
    {
        resources.SetPrice(wl.upg_wall_cost, wl.upg_stone_cost);
        resources.UpdateAll();
    }

    public void MouseEnterButtonDelete(Button b)
    {
        resources.SetRefund(wl.del_wood_re, wl.del_stone_re);
        resources.UpdateAll();
    }

    public void MouseEnterButtonRepair(Button b)
    {
        resources.SetPrice(wl.rep_wood_cost, wl.rep_stone_cost);
        resources.UpdateAll();
    }

    public void MouseExitButton(Button b)
    {
        resources.ClearPriceOrRefund();
        resources.UpdateAll();
    }
}