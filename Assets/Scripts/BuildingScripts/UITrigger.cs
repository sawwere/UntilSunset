using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITrigger : MonoBehaviour
{
    private Wall wl;

    private void Start()
    {
        wl = transform.parent.GetComponent<Wall>();
    }

    private void OnMouseOver()
    {
        wl.DisplayDialog();
    }

    private void OnMouseExit()
    {
        wl.HideDialog();
    }
}