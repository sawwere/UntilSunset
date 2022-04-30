using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coffin : Building
{
    public GameObject dialogBox;
    private Resources resources;
    public bool playerisnear;

    protected override void Start()
    {
        HideDialog();
        maxHealth = 40;
        base.Start();
    }

    public void Recover()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if ((GameStats.Coins >= 5) && (health < maxHealth))
        {
            health = maxHealth;
            GameStats.Coins -= 5;
            resources.UpdateAll();
            UIHealthBar.instance.SetValue(health);
            HideDialog();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            HideDialog();
    }

    public void DisplayDialog()
    {
        dialogBox.SetActive(true);
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            DisplayDialog();

        EnemyCharacter e = other.gameObject.GetComponent<EnemyCharacter>();
        if (e)
        {
            Debug.Log("base under attack");
            RecieveDamage(e.damage);
            UIHealthBar.instance.SetValue(health / (float)maxHealth); // устанавливает новое значение для полоски здоровья
            Destroy(e.gameObject);
        }
    }

    new public void RecieveDamage(int amount)
    {
        health -= amount;
        UIHealthBar.instance.SetValue(health / (float)maxHealth); // устанавливает новое значение для полоски здоровья
        if (health <= 0)
        {
            Destroy(this);
            FindObjectOfType<PauseMenu>().Lose();
            Debug.Log(name + " has been destoyed");
        }
    }
}
