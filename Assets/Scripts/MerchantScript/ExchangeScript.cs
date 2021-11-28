using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void WoodToCoinButtonPressed()
    {
        if (GameStats.Wood >= 3)
        {
            GameStats.Wood -= 3;
            GameStats.Coins += 1;
            Debug.Log(GameStats.Coins);
        }
    }

    public void CoinToWoodButtonPressed()
    {
        if (GameStats.Coins >= 1)
        {
            GameStats.Coins -= 1;
            GameStats.Wood += 1;
            Debug.Log(GameStats.Wood);
        }
    }

    public void StoneToCoinButtonPressed()
    {
        if (GameStats.Stone >= 3)
        {
            GameStats.Stone -= 3;
            GameStats.Coins += 2;
        }
    }
}
