using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseAtack : MonoBehaviour
{
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponent<IDamage>();
        if (obj != null && collision.gameObject.tag!="Enemy")
        {
            transform.parent.gameObject.GetComponent<EnemyClose>().DoDamage(obj);
        }
    }
}
