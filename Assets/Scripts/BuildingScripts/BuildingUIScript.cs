using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUIScript : MonoBehaviour
{
    public GameObject wll1;

    public void BuildWallButton()
    {
        BuildPlace_1.obj_struct = wll1;
        GameObject.Find("BuildingUI/StructText").GetComponent<Text>().text = "Выбранная пострйока: стена";
    }
}
