using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollectable : MonoBehaviour
{
    private Resources resources;
    private void Start()
    {
        resources = GameObject.Find("StoneText").GetComponent<Resources>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        Debug.Log(666);
        if (controller != null)
        {
            GameStats.Stone += 1;
            resources.UpdateStones();
            Destroy(gameObject);
        }
    }
}
