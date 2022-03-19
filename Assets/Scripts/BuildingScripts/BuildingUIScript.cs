using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUIScript : MonoBehaviour
{
    public GameObject wll1;
    public GameObject wll1Ghost;
    public GameObject stakes;
    public GameObject stakesGhost;
    public GameObject tower;
    public GameObject towerGhost;

    public void BuildWallButton()
    {
        Building.tool = 0;
        BuildPlace_1.obj_struct = wll1;
        BuildPlace_1.obj_ghost = wll1Ghost;
        BuildPlace_1.obj_price = 3;
    }

    public void BuildStakesButton()
    {
        Building.tool = 0;
        BuildPlace_1.obj_struct = stakes;
        BuildPlace_1.obj_ghost = stakesGhost;
        BuildPlace_1.obj_price = 1;
    }

    public void BuildTowerButton()
    {
        Building.tool = 0;
        BuildPlace_1.obj_struct = tower;
        BuildPlace_1.obj_ghost = towerGhost;
        BuildPlace_1.obj_price = 5;
    }

    public void NullStruct()
    {
        BuildPlace_1.obj_struct = null;
        BuildPlace_1.obj_ghost = null;
        BuildPlace_1.obj_price = 0;
    }

    public void DestroyTool()
    {
        NullStruct();
        Building.tool = 3;
    }
}
