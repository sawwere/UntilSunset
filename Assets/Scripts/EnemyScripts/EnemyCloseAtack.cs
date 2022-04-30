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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<IDamage>();
        if (obj != null &&
            (((1 << collision.gameObject.layer) & parentEnemy.aviableHitMask.value) != 0))
        {
            
            var movable = collision.gameObject.GetComponent<IMovable>();
            if (movable != null)
            {
                //Debug.Log("enter");
                movable.SpeedResetToZero();
                parentEnemy.SpeedResetToZero(); ;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<IDamage>();
        //Debug.Log(collision.gameObject);
        if (obj != null && 
            (((1 << collision.gameObject.layer) & parentEnemy.aviableHitMask.value) != 0))
        {
            //Debug.Log(obj);
            //Debug.Log("stay");
            transform.parent.gameObject.GetComponent<EnemyCharacter>().DoDamage(obj);
            //var movable = collision.gameObject.GetComponent<IMovable>();
            //if (movable != null && !parentEnemy.IsFriend())
            //{
            //    movable.SpeedResetToZero();
            //    parentEnemy.SpeedResetToZero();
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<IMovable>();
        if (obj != null &&
            ((1 << collision.gameObject.layer) & parentEnemy.aviableHitMask.value) != 0)
        {
            obj.SpeedRestore();
            parentEnemy.SpeedRestore();
        }
    }
}
