using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleHelp : MonoBehaviour
{
    TimeCycleTutorial timeCycle;

    void Start()
    {
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycleTutorial>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!timeCycle.en)
            timeCycle.en = true;
    }
}
