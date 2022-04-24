using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : Tree
{
    protected override void ObjectDie()
    {
        Destroy(gameObject);
    }
}