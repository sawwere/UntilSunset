using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinButton : MonoBehaviour
{
    private Coffin cof;

    public void CoffinButtonPressed()
    {
        cof = transform.parent.GetComponent<Coffin>();
        cof.Recover();
    }
}
