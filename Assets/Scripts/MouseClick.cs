using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    int layerMask;
    private BuildPlace_1 bp;
    private Wall_1 wll1;

    void Start()
    {
        LayerMask.GetMask("NPC", "Environment", "Buildings");
        layerMask = LayerMask.GetMask("Environment", "Buildings");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, layerMask);
            if ((hit == true) && (hit.collider.gameObject.tag == "BuildPlace"))
            {
                bp = hit.collider.gameObject.GetComponent<BuildPlace_1>();
                bp.DisplayDialog();
            }

            if ((hit == true) && (hit.collider.gameObject.tag == "Wall1"))
            {
                wll1 = hit.collider.gameObject.GetComponent<Wall_1>();
                wll1.DisplayDialog();
            }
        }
    }
}
