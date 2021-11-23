using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBat : MonoBehaviour
{
    public GameObject spawnPoint;

    public static SpawnBat instance = null;
    public GameObject bat;
    private Resources resources;
    public int priceOfBat = 2;
    int batOnScreen = 0;//���-�� ����� �� ������ ������

    void Start()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void OnClick()
    {
        if (GameStats.Coins >= priceOfBat)
        {
            Spawn();
            GameStats.Coins -= priceOfBat;
            resources.UpdateCoins();
        }
    }

    void Spawn()
    {
        GameObject newbat = Instantiate(bat) as GameObject;
        newbat.transform.position = spawnPoint.transform.position;

    }
}
