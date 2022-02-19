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

    public void BuildWallButton()
    {
        BuildPlace_1.obj_struct = wll1;
        BuildPlace_1.obj_ghost = wll1Ghost;
        BuildPlace_1.obj_price = 3;
    }

    public void BuildStakesButton()
    {
        BuildPlace_1.obj_struct = stakes;
        BuildPlace_1.obj_ghost = stakesGhost;
        BuildPlace_1.obj_price = 1;
    }
}
