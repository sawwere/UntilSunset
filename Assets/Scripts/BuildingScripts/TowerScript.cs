using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : Building, IDamage
{
    private BuildPlace_1 bp;
    public GameObject arrow;
    private Resources resources;
    private GameObject arr;
    public bool et;
    public int sc;
    public int rep_wood_cost = 2;
    public int rep_stone_cost = 1;
    public int del_wood_re = 1;
    public int del_stone_re = 1;

    public float timerDisplay;
    float displayTime = 4;
    public GameObject dialogBox;

    protected override void Start()
    {
        bp = transform.parent.GetComponent<BuildPlace_1>();
        et = false;
        sc = bp.direction;
        transform.localScale = new Vector3(transform.localScale.x * sc, transform.localScale.y, transform.localScale.z);
        bp.GetComponent<BoxCollider2D>().enabled = false;
        maxHealth = 3;
        base.Start();
    }

    private void Update()
    {
        Debug.Log(et);
        Debug.Log(timerDisplay);
        if ((timerDisplay >= 0) && et)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                Shot();
                timerDisplay = displayTime;
            }
        }
    }

    public void Recover()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if ((GameStats.Wood >= rep_wood_cost) && (GameStats.Stone >= rep_stone_cost) && (health != maxHealth))
        {
            GameStats.Wood -= rep_wood_cost;
            GameStats.Stone -= rep_stone_cost;
            resources.UpdateWood();
            resources.UpdateStones();
            HideDialog();
            health = maxHealth;

        }
    }

    public void DoDamage(IDamage obj)
    {
        obj.RecieveDamage(1);
    }

    public void DestroyStruct()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        GameStats.Wood += del_wood_re;
        GameStats.Stone += del_stone_re;
        resources.UpdateWood();
        resources.UpdateStones();
        Destroy(gameObject);
    }

    protected void OnDestroy()
    {
        bp.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void Shot()
    {
        arr = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), transform.rotation);
        arr.transform.SetParent(this.transform);
    }

    public void DisplayDialog()
    {
        dialogBox.SetActive(true);
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
    }

}
