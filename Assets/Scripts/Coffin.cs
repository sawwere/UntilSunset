using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coffin : Building
{
    public GameObject dialogBox;
    private Resources resources;

    private float displayPeriod = 0.5f;
    private float displayTimer;
    private bool showDialog;
    private bool playerIsNear;

    protected override void Start()
    {
        HideDialog();
        maxHealth = 40;
        displayTimer = displayPeriod;
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

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.CompareTo("Player") == 0)
        {
            displayTimer = displayPeriod;
            showDialog = false;
            playerIsNear = false;
        }
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
        if (other.gameObject.tag.CompareTo("Player") == 0)
        {
            playerIsNear = true;
        }

        if ((other.gameObject.tag.CompareTo("Player") == 0) && (health != maxHealth))
        {
            DisplayDialog();
            showDialog = true;
        }
    }

    private void Update()
    {
        if (dialogBox.activeInHierarchy)
            displayTimer -= Time.deltaTime;
        if (displayTimer <= 0 && !showDialog)
            dialogBox.SetActive(false);

        if ((playerIsNear) && (health != maxHealth))
        {
            DisplayDialog();
        }
    }

    new public void RecieveDamage(int amount, DamageType damageType)
    {
        health -= amount;
        UIHealthBar.instance.SetValue(health / (float)maxHealth); // ������������� ����� �������� ��� ������� ��������
        if (health <= 0)
        {
            Destroy(this);
            FindObjectOfType<PauseMenu>().Lose();
            Debug.Log(name + " has been destoyed");
        }
    }

    public bool IsUndamaged()
    {
        return maxHealth == health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
