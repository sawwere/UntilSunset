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
        var obj = collision.gameObject.GetComponent<IDamage>();
        if (parentEnemy.target)
        {
            parentEnemy.DoDamage(obj);
        }
        else
        {
            if (obj != null && collision.gameObject.tag != "Enemy" && obj.GetLine() == parentEnemy.GetLine())
            {
                SetTarget(collision.gameObject);
            }
        }
    }

    public void SetTarget(GameObject obj)
    {
        if (!parentEnemy.target)
        {
            parentEnemy.target = obj;
            parentEnemy.targetPoint = parentEnemy.target.transform.position;
            Debug.Log("target has been found");
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
