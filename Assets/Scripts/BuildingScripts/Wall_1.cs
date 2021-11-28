using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_1 : Wall
{
    public float displayTime = 5.0f;
    public GameObject dialogBox;
    public GameObject wall2;
    private Resources resources;
    float timerDisplay;

    protected override void Start()
    {
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

    public void UpgradeWall()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if (GameStats.Coins >= 3)
        {
            Instantiate(wall2, transform.position, transform.rotation);
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
