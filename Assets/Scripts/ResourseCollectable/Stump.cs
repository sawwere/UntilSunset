using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stump : Tree
{
    public Tree tree;

    protected override void Start()
    {
        base.Start();

        PlayerIsNear = tree.IsPlayerIsNear();
        resInd.SetActive(PlayerIsNear);
    }

    protected override void ObjectDie()
    {
        tree.anim.Play("Delete");
        Invoke(nameof(TurnToTree), 60f);
    }

    public override void TurnToTree()
    {
        tree.TurnToTree();
        RenewResource();
    }
}
