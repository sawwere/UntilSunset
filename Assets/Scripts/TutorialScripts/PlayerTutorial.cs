using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : PlayerController
{
    public GameObject dialogBox1;

    private Resources Res;

    protected override void Start()
    {
        base.Start();

        dialogBox1.SetActive(false);
        atHome = false;
    }

    protected override void Update()
    {
        /*if (!BuildHelp.GetFlag3() && BuildHelp.GetFlag2() && GameStats.Wood < 9)
        {
            GameStats.Wood += 10;
            Res.UpdateWood();
        }
        if (!BuildHelp.GetFlag3() && BuildHelp.GetFlag2() && GameStats.Stone < 3)
        {
            GameStats.Stone += 10;
            Res.UpdateStones();
        }
        if (BuildHelp.GetFlag3() && !BuildHelp.GetFlag5() && GameStats.Henchman < 5)
        {
            GameStats.Henchman += 5;
            Res.UpdateHenchman();
        }
        if (BuildHelp.GetFlag4() && !BuildHelp.GetFlag7() && GameStats.Wood < 4)
        {
            GameStats.Wood += 10;
            Res.UpdateWood();
        }
        if (BuildHelp.GetFlag4() && !BuildHelp.GetFlag7() && GameStats.Henchman < 3)
        {
            GameStats.Henchman += 3;
            Res.UpdateHenchman();
        }
        if (BuildHelp.GetFlag7() && GameStats.Stone < 3)
        {
            GameStats.Stone += 10;
            Res.UpdateStones();
        }
        if (MerchantHelp.GetFlag() && GameStats.Wood < 4)
        {
            GameStats.Wood += 10;
            Res.UpdateWood();
        }*/

        base.Update();
    }

    protected override IEnumerator GoRight()
    {
        StartCoroutine(ActiveDialog());

        while (transform.position.x < -52.5)
        {
            transform.Translate(isBat ? 0.04f : 0.02f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }

        isLeaving = false;
    }

    protected override IEnumerator GoLeft()
    {
        StartCoroutine(ActiveDialog());

        while (transform.position.x > 26.5)
        {
            transform.Translate(isBat ? -0.04f : -0.02f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }

        isLeaving = false;
    }

    private IEnumerator ActiveDialog()
    {
        dialogBox1.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        dialogBox1.SetActive(false);
    }

}
