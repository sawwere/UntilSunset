using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ResourceScript
{
    public Animator anim = null;

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
        resources.UpdateWood();
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
}
