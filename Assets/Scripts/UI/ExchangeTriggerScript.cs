using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeTriggerScript : MonoBehaviour
{
    private Resources resources; 

    private void Start()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
    }

    public void EnterStoneToCoinButton(Button b)
    {
        resources.SetPriceMerchant(0, 1, 0);
        resources.SetRefundMerchant(0, 0, 1);
        resources.UpdateAll();
    }

    public void EnterCoinToStoneButton(Button b)
    {
        resources.SetPriceMerchant(0, 0, 3);
        resources.SetRefundMerchant(0, 1, 0);
        resources.UpdateAll();
    }

    public void EnterWoodToCoinButton(Button b)
    {
        resources.SetPriceMerchant(3, 0, 0);
        resources.SetRefundMerchant(0, 0, 1);
        resources.UpdateAll();
    }

    public void EnterCoinToWoodButton(Button b)
    {
        resources.SetPriceMerchant(0, 0, 3);
        resources.SetRefundMerchant(5, 0, 0);
        resources.UpdateAll();
    }

    public void ExitExchangeButton(Button b)
    {
        resources.ClearPriceOrRefund();
        resources.UpdateAll();
    }

}
