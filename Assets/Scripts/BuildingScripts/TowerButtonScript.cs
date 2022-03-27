using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonScript : MonoBehaviour
{
    private TowerScript tw;
    private GameObject upginfo;
    private Resources resources;

    public void Start()
    {
        tw = transform.parent.GetComponent<TowerScript>();
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
    }
    public void WallRecoverButtonPressed()
    {
        tw.Recover();
    }

    public void WallDelButtonPressed()
    {
        tw.DestroyStruct();
    }

    public void MouseEnterButtonDelete(Button b)
    {
        resources.SetRefund(tw.del_wood_re, tw.del_stone_re);
        resources.UpdateAll();
    }

    public void MouseEnterButtonRepair(Button b)
    {
        resources.SetPrice(tw.rep_wood_cost, tw.rep_stone_cost);
        resources.UpdateAll();
    }

    public void MouseExitButton(Button b)
    {
        resources.ClearPriceOrRefund();
        resources.UpdateAll();
    }
}
