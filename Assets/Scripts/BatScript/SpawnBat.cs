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
    int batOnScreen = 0;//кол-во мышей на данный момент

    void Start()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
    }

    private void Update()
    {
        Spawn();
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    /*public void OnClick()
    {
        if (GameStats.Coins >= priceOfBat)
        {
            Spawn();
            GameStats.Coins -= priceOfBat;
            resources.UpdateCoins();
        }
    }*/

    void Spawn()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameStats.Coins >= priceOfBat)
            {
                GameObject newbat = Instantiate(bat) as GameObject;
                GameStats.Coins -= priceOfBat;
                resources.UpdateCoins();
                newbat.transform.position = spawnPoint.transform.position;
            }
        }
    }
}
