using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItriggerTower : MonoBehaviour
{
    private TowerScript tw;

    private void Start()
    {
        Debug.Log(1);
        tw = transform.parent.GetComponent<TowerScript>();
    }

    private void OnMouseOver()
    {
        Debug.Log(1);
        tw.DisplayDialog();
    }

    private void OnMouseExit()
    {
        tw.HideDialog();
    }
}
