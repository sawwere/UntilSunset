using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : ResourceScript
{
    protected override void CollectItem()
    {
        base.CollectItem();
        DTime = 0.0f;
        GameStats.Stone += 1;
        resources.UpdateStones();
    }
}
