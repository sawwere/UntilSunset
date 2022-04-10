using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : Tree
{
    public Tree tree;

    protected override void ObjectDie()
    {
        tree.anim.Play("Delete");
        Invoke(nameof(TurnToTree), Random.Range(110, 130));
    }

    public override void TurnToTree()
    {
        tree.TurnToTree();
        RenewResource();
    }
}