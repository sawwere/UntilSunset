using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClickedEvent : MonoBehaviour
{
    private PlayerController player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            var parent = hit.transform?.parent;
            GameObject enemy;
            if (transform.parent && (enemy = transform.parent.gameObject))
            {
                player.SubdueEnemy(enemy.GetComponent<EnemyCharacter>());
                Debug.Log("click");
            }
        }
    }
}
