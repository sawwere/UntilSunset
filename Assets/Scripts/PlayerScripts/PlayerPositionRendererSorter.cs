using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionRendererSorter : MonoBehaviour
{
    [SerializeField]
    private int sotringOrderBase = 1000;

    private float timer;
    private float timerMax = .1f;

    private float offset = 0;

    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = timerMax;
            myRenderer.sortingOrder = (int)(sotringOrderBase - transform.position.y * 10 - offset);
        }
    }
}
