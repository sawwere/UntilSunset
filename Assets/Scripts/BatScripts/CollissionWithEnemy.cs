using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionWithEnemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<EnemyCharacter>();
        if (obj != null)
        {
            obj.SpeedResetToZero();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<IDamage>();
        if (obj != null)
        {
            transform.parent.gameObject.GetComponent<Bat>().DoDamage(obj);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<EnemyCharacter>();
        if (obj != null)
        {
            collision.gameObject.GetComponent<EnemyCharacter>().SpeedRestore();
            Debug.Log(collision.gameObject.GetComponent<EnemyCharacter>().speed);
        }
    }
}
