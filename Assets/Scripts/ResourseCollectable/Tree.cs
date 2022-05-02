using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Wood
{
    public Animator anim = null;

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

    protected override void SetPEValues()
    {
        resLim *= 2;
        DTimeMax *= 0.75f;
        resInd.transform.localScale *= 1.25f;
    }
}
