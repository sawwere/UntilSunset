using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseAtack : MonoBehaviour
{
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        Building b = collision.GetComponent<Building>();
        if ((b != null)&&(b.GetType()!=typeof(MainBuilding)))
            transform.parent.gameObject.GetComponent<EnemyClose>().DoDamage(collision);
    }
}
