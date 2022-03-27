using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{

    public TextMeshProUGUI CountCoins;
    public TextMeshProUGUI CountWood;
    public TextMeshProUGUI CountStones;
    public TextMeshProUGUI CountHeanchman;
    private string woodprice = "";
    private string stoneprice = "";
    // Start is called before the first frame update
    void Start()
    {
        UpdateAll();
    }

    // Устанавливает новое значение для Coins
    public void UpdateCoins()
    {
      
        CountCoins.text = GameStats.Coins.ToString();
    }

    public void UpdateWood()
    {

        CountWood.text = GameStats.Wood.ToString() + woodprice;
    }

    public void UpdateStones()
    {
        CountStones.text = GameStats.Stone.ToString() + stoneprice;
    }

    public void UpdateHenchman()
    {
        CountHeanchman.text = GameStats.Henchman.ToString();
    }

    public void SetPrice(int wp, int sp)
    {
        if (wp != 0)
            woodprice = " - " + wp.ToString();
        if(sp != 0)
            stoneprice = " - " + sp.ToString();
    }

    public void SetRefund(int wr, int sr)
    {
        if (wr != 0)
            woodprice = " + " + wr.ToString();
        if (sr != 0)
            stoneprice = " + " + sr.ToString();
    }

    public void ClearPriceOrRefund()
    {
        woodprice = "";
        stoneprice = "";
    }


    public void UpdateAll()
    {
        UpdateCoins();
        UpdateWood();
        UpdateStones();
        UpdateHenchman();
    }
}
