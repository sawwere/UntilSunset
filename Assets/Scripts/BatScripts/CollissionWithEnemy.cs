using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionWithEnemy : MonoBehaviour
{
    Bat parentBat;

    private void Start()
    {
        parentBat = transform.parent.gameObject.GetComponent<Bat>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<EnemyCharacter>();
        if (obj != null)
        {
            obj.SpeedResetToZero();
            Debug.Log("enemy");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<IDamage>();
        if (obj != null
            && (((1 << collision.gameObject.layer) & parentBat.aviableHitMask.value) != 0))
        {
            transform.parent.gameObject.GetComponent<Bat>().DoDamage(obj);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<EnemyCharacter>();
        if (obj != null)
        {
            obj.SpeedRestore();
            transform.parent.gameObject.GetComponent<Bat>().speed = transform.parent.gameObject.GetComponent<Bat>().speedInit;
        }
    }
}
