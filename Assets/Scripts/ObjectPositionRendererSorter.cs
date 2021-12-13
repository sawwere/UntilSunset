using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionRendererSorter : MonoBehaviour
{
    private int sotringOrderBase = 1000;

    [SerializeField]
    private float offset = 0.0f;

    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(sotringOrderBase - transform.position.y * 10 - offset);
        Destroy(this);
    }
}
