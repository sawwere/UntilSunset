using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceIndicator : MonoBehaviour
{
    public bool mousepressed = false;

    private void OnMouseDown()
    {
        mousepressed = true;
        Debug.Log("Down");
    }

    private void OnMouseUp()
    {
        mousepressed = false;
        Debug.Log("Up");
    }

    private void OnMouseExit()
    {
        mousepressed = false;
        Debug.Log("Exit");
    }

}