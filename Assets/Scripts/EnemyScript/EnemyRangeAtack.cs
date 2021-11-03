using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAtack : MonoBehaviour
{
    EnemyRange parentEnemy; 

    private void Start()
    {
        parentEnemy = transform.parent.gameObject.GetComponent<EnemyRange>();
    }
    /*
     * private void OnTriggerEnter2D(Collider2D collision)
    {
        Wall_1 wall = collision.GetComponent<Wall_1>();
        if (wall)
            SetTarget(collision);
    }
    */

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (parentEnemy.target)
            parentEnemy.DoDamage(collision);
        else
        {
            Building b = collision.GetComponent<Building>();
            if ((b != null) && (b.GetType() != typeof(MainBuilding)))
                SetTarget(collision);
        }
    }

    public void SetTarget(Collider2D collision)
    {
        if (!parentEnemy.target)
        {
            parentEnemy.target = collision.GetComponent<Building>();
            parentEnemy.targetPoint = parentEnemy.target.transform.position;
            Debug.Log("target has been found");
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
