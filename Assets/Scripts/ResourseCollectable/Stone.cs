using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stone : ResourceScript
{
    private TextMeshProUGUI tcount;

    protected override void Start()
    {
        base.Start();

        tcount = GameObject.FindWithTag("StoneCount").GetComponent<TextMeshProUGUI>();
        tcount.SetText("0");
    }

    protected override void CollectItem()
    {
        base.CollectItem();
        DTime = 0.0f;
        GameStats.Stone += 1;
        tcount.SetText(GameStats.Stone.ToString());
    }
}
