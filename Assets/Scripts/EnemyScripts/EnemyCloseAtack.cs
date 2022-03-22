using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseAtack : MonoBehaviour
{
    EnemyCharacter parentEnemy;

    private void Start()
    {
        parentEnemy = transform.parent.gameObject.GetComponent<EnemyCharacter>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<IDamage>();
        if (obj != null && 
            (((1 << collision.gameObject.layer) & parentEnemy.aviableHitMask.value) != 0))
        {
            transform.parent.gameObject.GetComponent<EnemyCharacter>().DoDamage(obj);
        }
    }
}
