using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ResourceScript
{
    public Animator anim = null;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (Input.GetKeyDown(KeyCode.U)) // Чит код для восстановления деревьев преждевременно
            TurnToTree();
    }

    protected override void CollectItem()
    {
        base.CollectItem();

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
