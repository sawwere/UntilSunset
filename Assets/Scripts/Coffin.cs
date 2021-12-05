using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coffin : Building
{
    public float displayTime = 5.0f;
    public GameObject dialogBox;
    private Resources resources;
    float timerDisplay;

    protected override void Start()
    {
        HideDialog();
        timerDisplay = -1.0f;
        maxHealth = 3;
        base.Start();
    }

    public void Recover()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if ((GameStats.Stone >= 3) && (health < maxHealth))
        {
            health = maxHealth;
            GameStats.Stone -= 3;
            resources.UpdateStones();
            UIHealthBar.instance.SetValue(health);
            HideDialog();
        }
    }

    private void OnMouseDown()
    {
        DisplayDialog();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyCharacter e = other.gameObject.GetComponent<EnemyCharacter>();
        if (e)
        {
            Debug.Log("base under attack");
            //RecieveDamage(e.damage);
            UIHealthBar.instance.SetValue(health / (float)maxHealth); // устанавливает новое значение для полоски здоровья
            Destroy(e.gameObject);
        }
    }
}
