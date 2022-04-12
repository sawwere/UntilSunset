using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : Tree
{
    protected override void ObjectDie()
    {
        Destroy(gameObject);
    }

    protected override void WhenRes0()
    {
        base.WhenRes0();
        resInd.GetComponent<Animator>().Play("Bush");
    }
}
