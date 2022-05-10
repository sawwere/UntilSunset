using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExchangeScript : MonoBehaviour
{
    private Resources res;
    private AudioSource source;
    public AudioClip CCoin;
    public AudioClip CNo;

    private int StoneToCoinPrice = 1; // цена (сколько потеряем камней)
    private int StoneToCoinIncome = 1; // доход (сколько получим монет)

    private int CoinToStonePrice = 2; // цена (сколько потеряем монет)
    private int CoinToStoneIncome = 1; // доход (сколько получим камней)

    private int WoodToCoinPrice = 4; // цена (сколько потеряем дерева)
    private int WoodToCoinIncome = 1; // доход (сколько получим монет)

    private int CoinToWoodPrice = 1; // цена (сколько потеряем монет)
    private int CoinToWoodIncome = 3; // доход (сколько получим дерева)

    // Start is called before the first frame update
    private void Start()
    {
        res = GameObject.Find("CoinsText").GetComponent<Resources>();
        source = GameObject.FindGameObjectWithTag("Merchant").GetComponent<AudioSource>();
    }

    public void StoneToCoinButtonPressed()
    {
        if (GameStats.Stone >= StoneToCoinPrice)
        {
            GameStats.Stone -= StoneToCoinPrice;
            GameStats.Coins += StoneToCoinIncome;
            res.UpdateAll();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            source.PlayOneShot(CCoin, 0.2f);
        }
        else source.PlayOneShot(CNo, 0.4f);
    }

    public void CoinToStoneButtonPressed()
    {
        if (GameStats.Coins >= CoinToStonePrice)
        {
            GameStats.Coins -= CoinToStonePrice;
            GameStats.Stone += CoinToStoneIncome;
            res.UpdateAll();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            source.PlayOneShot(CCoin, 0.2f);
        }
        else source.PlayOneShot(CNo, 0.4f);
    }

    public void WoodToCoinButtonPressed()
    {
        if (GameStats.Wood >= WoodToCoinPrice)
        {
            GameStats.Wood -= WoodToCoinPrice;
            GameStats.Coins += WoodToCoinIncome;
            res.UpdateAll();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            source.PlayOneShot(CCoin, 0.2f);
        }
        else source.PlayOneShot(CNo, 0.4f);
    }

    public void CoinToWoodButtonPressed()
    {
        if (GameStats.Coins >= CoinToWoodPrice)
        {
            GameStats.Coins -= CoinToWoodPrice;
            GameStats.Wood += CoinToWoodIncome;
            res.UpdateAll();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            source.PlayOneShot(CCoin, 0.2f);
        }
        else source.PlayOneShot(CNo, 0.4f);
    }
}
