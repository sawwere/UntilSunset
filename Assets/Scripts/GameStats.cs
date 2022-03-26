using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[System.Serializable]
public class GameStats:MonoBehaviour
{
    public GameObject e1;
    public GameObject e2;
    public GameObject e3;
    public GameObject e4;
    public GameObject e5;
    public GameObject e6;
    public GameObject e7;
    public GameObject e8;
    public GameObject e9;
    public Vector3 spawnPointEnemy;

    public GameObject bat;
    public Vector3 spawnPointBat;


    private static int level;

    private static int encounter;

    public static List<SpawnerScript> spawnerList;

    public static List<List<EnemyCharacter>> enemyOnScreen;

    public static int Encounter
    {
        get { return encounter; }
        set { encounter = value; if (encounter == 3) FindObjectOfType<PauseMenu>().Win(); }
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

    private static int henchman = 0;

    public static int Henchman
    {
        get { return henchman; }
        set { henchman = value; }
    }
    void Awake()
    {
        Encounter = 0;
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
        Henchman = 0;
    }

}
