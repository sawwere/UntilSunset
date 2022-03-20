using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : Wall
{
    private BuildPlace_1 bp;
    public GameObject arrow;
    private Resources resources;
    public int sc;

    protected override void Start()
    {
        bp = transform.parent.GetComponent<BuildPlace_1>();
        sc = bp.direction;
        transform.localScale = new Vector3(transform.localScale.x * sc, transform.localScale.y, transform.localScale.z);
        bp.GetComponent<BoxCollider2D>().enabled = false;
        maxHealth = 3;
        base.Start();
    }

    private void OnMouseDown()
    {
        if (tool == 3)
        {
            DestroyStruct();
        }
    }

    public void DestroyStruct()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        GameStats.Wood += 3;
        GameStats.Stone += 1;
        resources.UpdateWood();
        resources.UpdateStones();
        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        bp.GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            var arr = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), transform.rotation);
            arr.transform.SetParent(this.transform);
        }
    }

}
