using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : ResourceScript
{
    protected override void CollectItem()
    {
        base.CollectItem();

        GameStats.Wood += 1;
        resources.UpdateWood();
    }
}
