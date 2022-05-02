using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceIndicator : MonoBehaviour
{
    public bool isMousePressed = false;

    private SpriteRenderer sprite;
    private Color color;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.material.color;
        color.a = 0.4f;
        sprite.material.color = color;
    }

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