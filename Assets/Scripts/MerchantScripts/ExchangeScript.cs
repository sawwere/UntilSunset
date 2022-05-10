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

    private int StoneToCoinPrice = 1; // ���� (������� �������� ������)
    private int StoneToCoinIncome = 1; // ����� (������� ������� �����)

    private int CoinToStonePrice = 2; // ���� (������� �������� �����)
    private int CoinToStoneIncome = 1; // ����� (������� ������� ������)

    private int WoodToCoinPrice = 4; // ���� (������� �������� ������)
    private int WoodToCoinIncome = 1; // ����� (������� ������� �����)

    private int CoinToWoodPrice = 1; // ���� (������� �������� �����)
    private int CoinToWoodIncome = 3; // ����� (������� ������� ������)

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
