using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Building, IDamage
{

    public void DoDamage(IDamage obj)
    {
        obj.RecieveDamage(1);
    }
}
