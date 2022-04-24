using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItriggerTower : MonoBehaviour
{
    private TowerScript tw;

    private void Start()
    {
        tw = transform.parent.GetComponent<TowerScript>();
    }

    private void OnMouseOver()
    {

        tw.DisplayDialog();
    }

    private void OnMouseExit()
    {
        tw.HideDialog();
    }
}
