using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseAtack : MonoBehaviour
{
    EnemyCharacter parentEnemy;

    int colliderCount;

    private void Start()
    {
        parentEnemy = transform.parent.gameObject.GetComponent<EnemyCharacter>();
        colliderCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<IDamage>();
        if (obj != null &&
            (((1 << collision.gameObject.layer) & parentEnemy.aviableHitMask.value) != 0))
        {
            
            var movable = collision.gameObject.GetComponent<IMovable>();
            if (movable != null)
            {
                //movable.SpeedResetToZero();
                parentEnemy.SpeedResetToZero(); ;
                colliderCount++;
            }
        }
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<IMovable>();
        if (obj != null &&
            ((1 << collision.gameObject.layer) & (parentEnemy.aviableHitMask.value | (1 << parentEnemy.gameObject.layer))) != 0)
        {
            colliderCount--;
            if (colliderCount == 0)
            {
                //obj.SpeedRestore();
                parentEnemy.SpeedRestore();
            }
        }
    }
}
