using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceIndicator : MonoBehaviour
{
    public bool isMousePressed = false;

    private void OnMouseDown()
    {
        isMousePressed = true;
    }

    private void OnMouseUp()
    {
        isMousePressed = false;
    }

    private void OnMouseExit()
    {
        isMousePressed = false;
    }

}