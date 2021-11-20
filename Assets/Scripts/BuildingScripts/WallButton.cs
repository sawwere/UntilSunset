using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    private BuildPlace_1 bp;
    private Wall_1 wll1;

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
}
