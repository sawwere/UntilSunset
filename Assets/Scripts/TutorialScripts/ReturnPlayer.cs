using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPlayer : MonoBehaviour
{
    public int direction = 1;

    private void Update()
    {
        if (!BuildHelp.GetFlag3() && BuildHelp.GetFlag2() && GameStats.Wood < 9)
            GameStats.Wood += 10;
        if (!BuildHelp.GetFlag3() && BuildHelp.GetFlag2() && GameStats.Stone < 3)
            GameStats.Stone += 10;
        if (BuildHelp.GetFlag3() && !BuildHelp.GetFlag5() && GameStats.Henchman < 5)
            GameStats.Henchman += 5;
        if (BuildHelp.GetFlag4() && !BuildHelp.GetFlag7() && GameStats.Wood < 4)
            GameStats.Wood += 10;
        if(BuildHelp.GetFlag4() && !BuildHelp.GetFlag7() && GameStats.Henchman < 3)
            GameStats.Henchman += 3;
        if(BuildHelp.GetFlag7() && GameStats.Stone < 3)
            GameStats.Stone += 10;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Player")
        {
            var obj = collision.gameObject.GetComponent<PlayerTutorial>();

            if (direction == 1)
                obj.ReturnRight();
            else obj.ReturnLeft();
        }
    }
 
}