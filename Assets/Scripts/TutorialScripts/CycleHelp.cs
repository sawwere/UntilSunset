using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleHelp : MonoBehaviour
{
    TimeCycleTutorial timeCycle;
    public GameObject dialogBox1;

    void Start()
    {
        dialogBox1.SetActive(false);
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycleTutorial>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogBox1.SetActive(true);
        if (!timeCycle.en)
            timeCycle.en = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogBox1.SetActive(false);
    }
}
