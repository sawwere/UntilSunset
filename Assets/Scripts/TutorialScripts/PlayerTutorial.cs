using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : PlayerController
{
    public bool isLeaving { get; set; }

    protected override void Start()
    {
        base.Start();

        atHome = false;
    }

    protected override void Update()
    {
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
}
