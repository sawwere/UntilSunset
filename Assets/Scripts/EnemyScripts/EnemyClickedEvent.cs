using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClickedEvent : MonoBehaviour
{
    private PlayerController player;
    private PauseMenu pauseMenu;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        pauseMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
    }

    private void OnMouseDown()
    {
        player.SubdueEnemy(gameObject.GetComponent<EnemyCharacter>());
        pauseMenu.ChooseText.SetActive(false);
    }
}
