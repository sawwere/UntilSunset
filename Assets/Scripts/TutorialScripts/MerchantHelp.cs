using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MerchantHelp : MonoBehaviour
{
    public GameObject dialogBox1;

    public GameObject player;

    public static bool flag = false;
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
        if (GameStats.Coins >= 1)
            dialogBox1.SetActive(false);
    }


    private void Update()
    {
        if (GameStats.Coins >= 1)
        {
            dialogBox1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Теперь посмотрим, как оборонтяться. Для этого выйдете из дома направо";
        }
        if (BuildHelp.GetFlag3())
            dialogBox1.SetActive(false);
    }

    public static bool GetFlag() { return flag; }
}
