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

    public float timerDisplay;
    float displayTime = 4;

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

    public void DoDamage(IDamage obj)
    {
        obj.RecieveDamage(1);
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

    protected void OnDestroy()
    {
        bp.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void Shot()
    {
        arr = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), transform.rotation);
        arr.transform.SetParent(this.transform);
    }

}
