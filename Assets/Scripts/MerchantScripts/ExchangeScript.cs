using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeScript : MonoBehaviour
{
    private Resources CoinsRes;
    private Resources WoodRes;
    private Resources StoneRes;
    private Resources HenchmanRes;

    // Start is called before the first frame update
    private void Start()
    {
        CoinsRes= GameObject.Find("CoinsText").GetComponent<Resources>();
        WoodRes = GameObject.Find("WoodText").GetComponent<Resources>();
        StoneRes = GameObject.Find("StoneText").GetComponent<Resources>();
        HenchmanRes = GameObject.Find("HenchmenText").GetComponent<Resources>();
    }
    public void WoodToCoinButtonPressed()
    {
        if (GameStats.Wood >= 3)
        {
            GameStats.Wood -= 3;
            GameStats.Coins += 1;
            CoinsRes.UpdateCoins();
            WoodRes.UpdateWood();
            Debug.Log(GameStats.Coins);
        }
    }

    public void CoinToWoodButtonPressed()
    {
        if (GameStats.Coins >= 1)
        {
            GameStats.Coins -= 1;
            GameStats.Wood += 1;
            CoinsRes.UpdateCoins();
            WoodRes.UpdateWood();
            Debug.Log(GameStats.Wood);
        }
    }

    public void StoneToCoinButtonPressed()
    {
        if (GameStats.Stone >= 3)
        {
            GameStats.Stone -= 3;
            GameStats.Coins += 2;
            CoinsRes.UpdateCoins();
            StoneRes.UpdateStones();
        }
    }

    public void BuyBatButtonPressed()
    {
        if (GameStats.Coins >= 2)
        {
            GameStats.Coins -= 2;
            GameStats.Henchman += 1;
            CoinsRes.UpdateCoins();
            HenchmanRes.UpdateHenchman();
        }
    }
}
