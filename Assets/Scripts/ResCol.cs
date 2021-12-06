using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResCol : MonoBehaviour
{
    private Collider2D col;
    private int count;
    private TimeCycle timeCycle;

    void Start()
    {
        count = 0;
        col = GetComponent<Collider2D>();
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycle>();
    }

    void Update()
    {
        if (timeCycle.GetIsDay())
            col.isTrigger = true;

        else if (!timeCycle.GetIsDay() && count == 0)
        {
            col.isTrigger = false;

        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        count++;
        //Debug.Log("Enter = " + count);
    }

    void OnTriggerExit2D (Collider2D coll)
    {
        count--;
       // Debug.Log("Exit = " + count);
    }
}
