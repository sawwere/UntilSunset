using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBat : MonoBehaviour
{
    public GameObject spawnPoint;

    public static SpawnBat instance = null;
    public GameObject bat;
    private Resources HenchmanRes;
    public int priceOfBat = 2;
    //int batOnScreen = 0;//кол-во мышей на данный момент

    void Start()
    {
        HenchmanRes = GameObject.Find("HenchmenText").GetComponent<Resources>();
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
        if (Input.GetKeyDown(KeyCode.E) && (GameStats.Henchman > 0))
        {
                GameObject newbat = Instantiate(bat) as GameObject;
                GameStats.Henchman--;
                HenchmanRes.UpdateHenchman();
                newbat.transform.position = spawnPoint.transform.position;
        }
    }
}
