using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tree : ResourceScript
{
    private TextMeshProUGUI tcount;
    public Animator anim = null;

    protected override void Start()
    {
        base.Start();

        tcount = GameObject.FindWithTag("WoodCount").GetComponent<TextMeshProUGUI>();
        tcount.SetText("0");
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.U)) // Чит код для восстановления деревьев преждевременно
            TurnToTree();
    }

    protected override void CollectItem()
    {
        base.CollectItem();
        DTime = 0.0f;
        GameStats.Wood += 1;
        tcount.SetText(GameStats.Wood.ToString());
    }

    protected override void ObjectDie()
    {
        TurnToStump();
    }

    private void TurnToStump()
    {
        anim.SetBool("isStump", true);
        Invoke(nameof(RenewResource), 1f);
    }

    public virtual void TurnToTree()
    {
        anim.SetBool("isStump", false);
    }

    public bool IsPlayerIsNear()
    {
        return PlayerIsNear;
    }
}
