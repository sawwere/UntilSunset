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

        CountWood.text = GameStats.Wood.ToString();
    }

    public void UpdateStones()
    {
        CountStones.text = GameStats.Stone.ToString();
    }

    public void UpdateHenchman()
    {
        CountHeanchman.text = GameStats.Henchman.ToString();
    }



    public void UpdateAll()
    {
        UpdateCoins();
        UpdateWood();
        UpdateStones();
        UpdateHenchman();
    }
}
