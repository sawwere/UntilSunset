using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats:MonoBehaviour
{
    private static int level;

    private static int encounter;

    public static List<SpawnerScript> spawnerList;

    public static List<List<EnemyCharacter>> enemyOnScreen;

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

    private static int stone = 0;
    public static int Stone
    {
        get { return stone; }
        set { stone = value; }
    }

    private static int wood = 0;
    public static int Wood
    {
        get { return wood; }
        set { wood = value; }
    }

    void Awake()
    {
        Encounter = 1;
        level = 1;
        spawnerList = new List<SpawnerScript>();
        enemyOnScreen = new List<List<EnemyCharacter>>();
        enemyOnScreen.Capacity = 3;
        for (int i = 0; i < 3; i++)
            enemyOnScreen.Add(new List<EnemyCharacter>());

        ResetStats();
    }

    private void ResetStats()
    {
        Coins = 0;
        Wood = 0;
        Stone = 0;
    }

}
