using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITrigger : MonoBehaviour
{
    private Wall wl;

    private void Start()
    {
        Debug.Log(1);
        wl = transform.parent.GetComponent<Wall>();
    }

    private void OnMouseOver()
    {
        Debug.Log(1);
        wl.DisplayDialog();
    }

    private void OnMouseExit()
    {
        wl.HideDialog();
    }
}