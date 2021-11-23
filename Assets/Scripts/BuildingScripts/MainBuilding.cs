using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e)
        {
            e.EnterMainBuilding();
        }
    }
}
