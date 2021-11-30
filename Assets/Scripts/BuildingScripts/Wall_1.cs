using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wall_1 : Wall
{
    public float displayTime = 5.0f;
    private bool upgraded = false;
    public GameObject dialogBox;
    public GameObject wall2;
    private Resources resources;
    private BuildPlace_1 bp;
    float timerDisplay;

    protected override void Start()
    {
        bp = transform.parent.GetComponent<BuildPlace_1>();
        bp.GetComponent<BoxCollider2D>().enabled = false;
        timerDisplay = -1.0f;
        dialogBox.SetActive(false);
        maxHealth = 2;
        base.Start();
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

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            DisplayDialog();
        }
    }

    public void OnDestroy()
    {
        if (!upgraded)
        {
            bp.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void UpgradeWall()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if (GameStats.Coins >= 3)
        {
            upgraded = true;
            var wall2inst = Instantiate(wall2, transform.position, transform.rotation);
            wall2inst.transform.SetParent(transform.parent.transform);
            GameStats.Coins -= 3;
            resources.UpdateCoins();
            HideDialog();
            Destroy(gameObject);
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }

    public void HideDialog()
    {
        dialogBox.SetActive(true);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
            DoDamage(e);
    }
    
}
