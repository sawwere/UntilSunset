using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyCharacter enemy = collision.gameObject.GetComponent<EnemyCharacter>();
        if (enemy)
        {
            enemy.EnterMainBuilding();
        }

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            player.EnterMainBuilding();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            player.ExitMainBuilding();
        }
    }
}
