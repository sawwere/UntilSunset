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
    public float BatPrice1 = 3;
    public float ThunderPrice = 5;
    // Start is called before the first frame update
    void Start()
    {
        GameStats.Henchman = 0;
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
        if (GameStats.Henchman == 0)
        {
            UIAbilities.instance.SetValue1(1);
            UIAbilities.instance.SetValue2(1);
        }
          if (GameStats.Henchman >= BatPrice1)
                UIAbilities.instance.SetValue1(0);
            else if (GameStats.Henchman != 0)
            UIAbilities.instance.SetValue1(1-(GameStats.Henchman / BatPrice1));

          if(GameStats.Henchman >= ThunderPrice)
            UIAbilities.instance.SetValue2(0);
          else if (GameStats.Henchman != 0)
            UIAbilities.instance.SetValue2(1 - (GameStats.Henchman / ThunderPrice));
        
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
