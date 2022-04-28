using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExchangeScript : MonoBehaviour
{
    private Resources CoinsRes;
    private Resources WoodRes;
    private Resources StoneRes;
    private Resources res;
    private AudioSource source;
    public AudioClip CCoin;
    public AudioClip CNo;

    // Start is called before the first frame update
    private void Start()
    {
        res = GameObject.Find("CoinsText").GetComponent<Resources>();
        //CoinsRes = GameObject.Find("CoinsText").GetComponent<Resources>();
        //WoodRes = GameObject.Find("WoodText").GetComponent<Resources>();
        //StoneRes = GameObject.Find("StoneText").GetComponent<Resources>();
        source = GameObject.FindGameObjectWithTag("Merchant").GetComponent<AudioSource>();
    }

    public void StoneToCoinButtonPressed()
    {
        if (GameStats.Stone >= 1)
        {
            GameStats.Stone -= 1;
            GameStats.Coins += 1;
            res.UpdateAll();
            //StoneRes.UpdateStones();
            //CoinsRes.UpdateCoins();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            source.PlayOneShot(CCoin, 0.2f);
        }
        else source.PlayOneShot(CNo, 0.4f);
    }

    public void CoinToStoneButtonPressed()
    {
        if (GameStats.Coins >= 3)
        {
            GameStats.Coins -= 3;
            GameStats.Stone += 1;
            res.UpdateAll();
            //CoinsRes.UpdateCoins();
            //StoneRes.UpdateStones();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            source.PlayOneShot(CCoin, 0.2f);
        }
        else source.PlayOneShot(CNo, 0.4f);
    }

    public void WoodToCoinButtonPressed()
    {
        if (GameStats.Wood >= 3)
        {
            GameStats.Wood -= 3;
            GameStats.Coins += 1;
            res.UpdateAll();
            //CoinsRes.UpdateCoins();
            //WoodRes.UpdateWood();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            source.PlayOneShot(CCoin, 0.2f);
        }
        else source.PlayOneShot(CNo, 0.4f);
    }

    public void CoinToWoodButtonPressed()
    {
        if (GameStats.Coins >= 3)
        {
            GameStats.Coins -= 3;
            GameStats.Wood += 5;
            res.UpdateAll();
            //CoinsRes.UpdateCoins();
            //WoodRes.UpdateWood();
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            source.PlayOneShot(CCoin, 0.2f);
        }
        else source.PlayOneShot(CNo, 0.4f);
    }
}
