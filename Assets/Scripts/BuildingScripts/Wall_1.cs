using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_1 : Wall
{
    public GameObject dialogBox;
    public GameObject wall2;
    private Resources resources;

    protected override void Start()
    {
        dialogBox.SetActive(false);
        maxHealth = 2;
        base.Start();
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
