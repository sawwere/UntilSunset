using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClickedEvent : MonoBehaviour
{
    //private PlayerController player;

    private void Awake()
    {
        //player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnMouseDown()
    {
        Debug.Log("4");
        //player.SubdueEnemy(gameObject.GetComponentInParent<EnemyCharacter>());
    }
}
