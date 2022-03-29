using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : PlayerController
{
    protected override void Start()
    {
        base.Start();

        atHome = false;
    }

    protected override void FixedUpdate()
    {
        /*if (!BuildHelp.GetFlag3() && BuildHelp.GetFlag2() && GameStats.Wood < 9)
            GameStats.Wood += 10;
        if (!BuildHelp.GetFlag3() && BuildHelp.GetFlag2() && GameStats.Stone < 3)
            GameStats.Stone += 10;
        if (BuildHelp.GetFlag3() && !BuildHelp.GetFlag5() && GameStats.Henchman < 5)
            GameStats.Henchman += 5;
        if (BuildHelp.GetFlag4() && !BuildHelp.GetFlag7() && GameStats.Wood < 4)
            GameStats.Wood += 10;
        if (BuildHelp.GetFlag4() && !BuildHelp.GetFlag7() && GameStats.Henchman < 3)
            GameStats.Henchman += 3;
        if (BuildHelp.GetFlag7() && GameStats.Stone < 3)
            GameStats.Stone += 10;*/

        base.FixedUpdate();
    }

    protected override IEnumerator GoRight()
    {
        while (transform.position.x < -52.5)
        {
            transform.Translate(isBat ? 0.04f : 0.02f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }

        isLeaving = false;
    }

    protected override IEnumerator GoLeft()
    {
        while (transform.position.x > 26.5)
        {
            transform.Translate(isBat ? -0.04f : -0.02f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }

        isLeaving = false;
    }
}
