using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats
{
    private static int level;

    private static int encounter;

    public static int Encounter
    {
        get { return encounter; }
        private set { encounter = value; }
    }

    public static int Level
    {
        get { return level; }
    }

    private static int coins = 0;
    public static int Coins
    {
        get { return coins; }
        set { coins = value; }
    }


    private static void Start()
    {
        Encounter = 1;
        level = 1;
    }
}
