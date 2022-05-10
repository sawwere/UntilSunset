using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeTriggerScript : MonoBehaviour
{
    private Resources resources;
    private ExchangeScript exchangeScript;

    private void Start()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        exchangeScript = transform.parent.GetComponent<ExchangeScript>();
    }

    public void EnterStoneToCoinButton(Button b)
    {
        resources.SetPriceMerchant(0, exchangeScript.StoneToCoinPrice, 0);
        resources.SetRefundMerchant(0, 0, exchangeScript.StoneToCoinIncome);
        resources.UpdateAll();
    }

    public void EnterCoinToStoneButton(Button b)
    {
        resources.SetPriceMerchant(0, 0, exchangeScript.CoinToStonePrice);
        resources.SetRefundMerchant(0, exchangeScript.CoinToStoneIncome, 0);
        resources.UpdateAll();
    }

    public void EnterWoodToCoinButton(Button b)
    {
        resources.SetPriceMerchant(exchangeScript.WoodToCoinPrice, 0, 0);
        resources.SetRefundMerchant(0, 0, exchangeScript.WoodToCoinIncome);
        resources.UpdateAll();
    }

    public void EnterCoinToWoodButton(Button b)
    {
        resources.SetPriceMerchant(0, 0, exchangeScript.CoinToWoodPrice);
        resources.SetRefundMerchant(exchangeScript.CoinToWoodIncome, 0, 0);
        resources.UpdateAll();
    }

    public void ExitExchangeButton(Button b)
    {
        resources.ClearPriceOrRefund();
        resources.UpdateAll();
    }

}
