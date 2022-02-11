using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUIScript : MonoBehaviour
{
    public GameObject wll1;
    public GameObject wll1Ghost;

    public void BuildWallButton()
    {
        BuildPlace_1.obj_struct = wll1;
        BuildPlace_1.obj_ghost = wll1Ghost;
        //GameObject.Find("BuildingUI/StructText").GetComponent<Text>().text = "Выбранная пострйока: стена";
    }
}
