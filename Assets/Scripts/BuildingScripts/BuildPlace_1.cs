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


    // Start is called before the first frame update
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
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController p = collision.GetComponent<PlayerController>();
        if (p != null)
        {
            //DisplayDialog();
            Instantiate(wall, transform.position, transform.rotation);
        }
    }
    */

    public void BuildWall()
    {
        Instantiate(wall, transform.position, transform.rotation);
    }

    public void BuildStruct(GameObject st, int value)
    {
        if (GameStats.Coins >= value)
        {
            Instantiate(st, transform.position, transform.rotation);
            GameStats.Coins -= value;
            resources.UpdateCoins();
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
