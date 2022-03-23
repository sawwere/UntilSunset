using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExchangeScript : MonoBehaviour
{
    private Resources CoinsRes;
    private Resources WoodRes;
    private Resources StoneRes;

    // Start is called before the first frame update
    private void Start()
    {
        CoinsRes = GameObject.Find("CoinsText").GetComponent<Resources>();
        WoodRes = GameObject.Find("WoodText").GetComponent<Resources>();
        StoneRes = GameObject.Find("StoneText").GetComponent<Resources>();
    }

    public void StoneToCoinButtonPressed()
    {
        if (GameStats.Stone >= 1)
        {
            GameStats.Stone -= 1;
            GameStats.Coins += 1;
            StoneRes.UpdateStones();
            CoinsRes.UpdateCoins();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
        }
    }

    public void CoinToStoneButtonPressed()
    {
        if (GameStats.Coins >= 3)
        {
            GameStats.Coins -= 3;
            GameStats.Stone += 1;
            CoinsRes.UpdateCoins();
            StoneRes.UpdateStones();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
        }
    }

    public void WoodToCoinButtonPressed()
    {
        if (GameStats.Wood >= 3)
        {
            GameStats.Wood -= 3;
            GameStats.Coins += 1;
            CoinsRes.UpdateCoins();
            WoodRes.UpdateWood();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
        }
    }

    public void CoinToWoodButtonPressed()
    {
        if (GameStats.Coins >= 3)
        {
            GameStats.Coins -= 3;
            GameStats.Wood += 5;
            CoinsRes.UpdateCoins();
            WoodRes.UpdateWood();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
        }
    }
}
