using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wall_2 : Wall
{
    public float displayTime = 5.0f;
    private BuildPlace_1 bp;
    private Resources resources;
    public GameObject dialogBox;
    float timerDisplay;

    protected override void Start()
    {
        HideDialog();
        timerDisplay = -1.0f;
        bp = transform.parent.GetComponent<BuildPlace_1>();
        maxHealth = 4;
        base.Start();
    }

    public void OnDestroy()
    {
        bp.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            DisplayDialog();
        }
    }

    public void Recover()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if ((GameStats.Wood >= 2) && (health < maxHealth))
        {
            health = maxHealth;
            GameStats.Wood -= 2;
            resources.UpdateWood();
            HideDialog();
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
    }

    private void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
            DoDamage(e);
    }
}
