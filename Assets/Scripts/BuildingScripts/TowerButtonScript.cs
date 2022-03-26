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

    public void MouseEnterButtonUpg(Button b)
    {
        //resources.SetChangeWood(1);
        resources.UpdateAll();
    }

    public void MouseExitButtonUpg(Button b)
    {
        //resources.ClearChangeWood();
        resources.UpdateAll();
    }
}
