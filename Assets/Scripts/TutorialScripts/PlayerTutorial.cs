using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTutorial : PlayerController
{
    public GameObject dialogBox1;

    private Resources Res;

    /*private void Awake()
    {
      //  Res = GameObject.Find("CoinsText").GetComponent<Resources>();
    }*/
    protected override void Start()
    {
        base.Start();

        Res = GameObject.Find("CoinsText").GetComponent<Resources>();
        dialogBox1.SetActive(false);
        atHome = false;


    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (GameStats.Wood < 700)
            {
                GameStats.Wood += 10;
                GameStats.Stone += 10;
                GameStats.Henchman += 10;
                Res.UpdateAll();
            }
        }

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
