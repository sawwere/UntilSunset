using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomHelp : MonoBehaviour
{
    public GameObject dialogBox1;

    public GameObject player;

    void Start()
    {
        dialogBox1.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogBox1.SetActive(true);
    }
}
