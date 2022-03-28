using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Building, IDamage
{
    public GameObject dialogBox;
    private bool upgraded = false;
    private Resources resources;
    public GameObject nextwall;
    private BuildPlace_1 bp;
    public AudioSource source;

    public int rep_wood_cost;
    public int rep_stone_cost;
    public int upg_wall_cost;
    public int upg_stone_cost;
    public int del_wood_re;
    public int del_stone_re;
    public AudioClip CDestroy;
    public AudioClip CRecover;
    public AudioClip CUpgrade;

    protected override void Start()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        source = GetComponent<AudioSource>();
        bp = transform.parent.GetComponent<BuildPlace_1>();
        bp.GetComponent<BoxCollider2D>().enabled = false;
        base.Start();
    }

    public void DoDamage(IDamage obj)
    {
        obj.RecieveDamage(10);
    }

    public void DestroyWall()
    {
        //resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        GameStats.Wood += del_wood_re;
        GameStats.Stone += del_stone_re;
        resources.UpdateWood();
        resources.UpdateStones();
        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        resources.ClearPriceOrRefund();
        resources.UpdateAll();
        HideDialog();
        if (!this.gameObject.scene.isLoaded) return;
        if (!upgraded)
        {
            bp.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void Recover()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if ((GameStats.Wood >= rep_wood_cost) && (GameStats.Stone >= rep_stone_cost) && (health != maxHealth))
        {
            source.PlayOneShot(CRecover, 0.5f);
            GameStats.Wood -= rep_wood_cost;
            GameStats.Stone -= rep_stone_cost;
            resources.UpdateWood();
            resources.UpdateStones();
            HideDialog();
            health = maxHealth;

        }
    }

    public void UpgradeWall()
    {
        //resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if ((GameStats.Wood >= upg_wall_cost) && (GameStats.Stone >= upg_stone_cost) )
        {
            upgraded = true;
            var wall2inst = Instantiate(nextwall, transform.position, transform.rotation);
            wall2inst.transform.SetParent(transform.parent.transform);
            GameStats.Wood -= upg_wall_cost;
            GameStats.Stone -= upg_stone_cost;
            resources.UpdateWood();
            resources.UpdateStones();
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
        dialogBox.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
            DoDamage(e);
    }
}
