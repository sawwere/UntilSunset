using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseAtack : MonoBehaviour
{
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        Wall_1 wall = collision.GetComponent<Wall_1>();
        if (wall != null)
            transform.parent.gameObject.GetComponent<EnemyClose>().DoDamage(collision);
    }
}
