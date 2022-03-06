using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    private BuildPlace_1 bp;
    private Wall_1 wll1;
    private Wall_2 wll2;
    private Wall_3 wll3;

    public void WallButtonPressed()
    {
        bp = transform.parent.GetComponent<BuildPlace_1>();
        bp.BuildWall();
    }

    public void WallUpgButtonPressed()
    {
        wll1 = transform.parent.GetComponent<Wall_1>();
        wll1.UpgradeWall();
    }

    public void Wall2UpgButtonPressed()
    {
        wll2 = transform.parent.GetComponent<Wall_2>();
        wll2.UpgradeWall();
    }

    public void Wall1RecoverButtonPressed()
    {
        wll1 = transform.parent.GetComponent<Wall_1>();
        wll1.Recover();
    }

    public void Wall2RecoverButtonPressed()
    {
        wll2 = transform.parent.GetComponent<Wall_2>();
        wll2.Recover();
    }

    public void Wall3RecoverButtonPressed()
    {
        wll3 = transform.parent.GetComponent<Wall_3>();
        wll3.Recover();
    }
}