using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollectable : MonoBehaviour
{
    private Resources resources;
    private void Start()
    {
        resources = GameObject.Find("WoodText").GetComponent<Resources>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            GameStats.Wood += 1;
            resources.UpdateWood();
            Destroy(gameObject);
        }
    }
}
