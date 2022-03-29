using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : PlayerController
{
    public GameObject dialogBox1;
    public bool isLeaving { get; set; }
    private Resources Res;

    protected override void Start()
    {
        base.Start();
        dialogBox1.SetActive(false);
        atHome = false;
    }

    protected override void Update()
    {
        if (!BuildHelp.GetFlag3() && BuildHelp.GetFlag2() && GameStats.Wood < 9)
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
        }
        if (isLeaving) return;

        base.Update();
    }

    protected override void FixedUpdate()
    {
        if (isLeaving) return;

        base.FixedUpdate();
    }

    public void ReturnRight()
    {
        isLeaving = true;


        animator.SetFloat("Speed", 1);
        animator.SetFloat("Horizontal", 1);
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("LastHorizontal", 1);
        animator.SetFloat("LastVertical", 0);

        StartCoroutine(GoRight());
        StartCoroutine(ActiveDialog());
    }

    private IEnumerator GoRight()
    {
        while (transform.position.x < -51.5)
        {
            transform.Translate(isBat ? 0.04f : 0.02f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }

        isLeaving = false;
    }

    public void ReturnLeft()
    {

        isLeaving = true;

        animator.SetFloat("Speed", 1);
        animator.SetFloat("Horizontal", -1);
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("LastHorizontal", -1);
        animator.SetFloat("LastVertical", 0);

        StartCoroutine(GoLeft());
        StartCoroutine(ActiveDialog());
    }

    private IEnumerator GoLeft()
    {
        while (transform.position.x > 30.75)
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
