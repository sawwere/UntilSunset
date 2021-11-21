using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlace_1 : MonoBehaviour
{

    public float displayTime = 10.0f;
    public GameObject dialogBox;
    public GameObject wall;
    float timerDisplay;
    private Resources resources;

    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;         
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void BuildWall()
    {
        if (GameStats.Coins >= 3)
        {
            Instantiate(wall, transform.position, transform.rotation);
            GameStats.Coins -= 3;
            resources.UpdateCoins();
            HideDialog();
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
    }
}
