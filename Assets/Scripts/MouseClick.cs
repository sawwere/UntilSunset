using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    int layerMask;
    private BuildPlace_1 bp;
    private static GameObject build;
    private static int value;
    // Start is called before the first frame update
    void Start()
    {
        LayerMask.GetMask("NPC", "Environment", "Buildings");
        layerMask = LayerMask.GetMask("Environment", "Buildings");
    }

    // Update is called once per frame
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
                if (build != null)
                    bp.BuildStruct(build, value);
            }
        }
    }

    public static void SetBuilding(GameObject building, int val)
    {
        build = building;
        value = val;
    }
}
