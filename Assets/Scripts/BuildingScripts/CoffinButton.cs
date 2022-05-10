using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoffinButton : MonoBehaviour
{
    private Coffin cof;
    private Resources resources;

    public void Start()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        cof = transform.parent.GetComponent<Coffin>();
    }

    public void CoffinButtonPressed()
    {
        cof.Recover();
    }

    public void EnterRecoverButton(Button b)
    {
        resources.SetPriceMerchant(0, 0, cof.recoverPrice);
        resources.UpdateAll();
    }

    public void ExitRecoverButton(Button b)
    {
        resources.ClearPriceOrRefund();
        resources.UpdateAll();
    }
}
