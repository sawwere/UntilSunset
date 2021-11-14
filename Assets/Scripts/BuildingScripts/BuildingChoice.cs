using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingChoice : MonoBehaviour
{
    public GameObject Wall1;
    public GameObject Wall2;

    public void Wall_1()
    {
        MouseClick.SetBuilding(Wall1, 3);
    }

    public void Wall_2()
    {
        MouseClick.SetBuilding(Wall2, 6);
    }
}
