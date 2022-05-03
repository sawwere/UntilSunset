using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject dialogBox;
    private float displayPeriod = 0.5f;
    private float displayTimer;
    private bool showDialog;

    void Start()
    {
        dialogBox.SetActive(false);
        displayTimer = displayPeriod;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.CompareTo("Player") == 0)
        {
            dialogBox.SetActive(true);
            showDialog = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.CompareTo("Player") == 0)
        {
            displayTimer = displayPeriod;
            showDialog = false;
        }
    }

    private void Update()
    {
        if (dialogBox.activeInHierarchy)
            displayTimer -= Time.deltaTime;
        if (displayTimer <= 0 && !showDialog)
        {
            dialogBox.SetActive(false);
            var resources = GameObject.Find("CoinsText").GetComponent<Resources>();
            resources.ClearPriceOrRefund();
            resources.UpdateAll();
        }

    }
}
