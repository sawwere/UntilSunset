using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionWithEnemy : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<IDamage>();
        if (obj != null)
        {
            transform.parent.gameObject.GetComponent<Bat>().DoDamage(obj);
        } 
    }
}
