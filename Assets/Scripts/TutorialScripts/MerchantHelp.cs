using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantHelp : MonoBehaviour
{
    public GameObject dialogBox1;

    public GameObject player;

    bool flag = false;
    void Start()
    {
        dialogBox1.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!flag)
        {
            dialogBox1.SetActive(true);
            flag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogBox1.SetActive(false);
    }


    private void Update()
    {
        if (GameStats.Coins >= 1)
            return;
    }
}
