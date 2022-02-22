using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjectGroupRendererSorter : MonoBehaviour
{
    private int sotringOrderBase = 1000;
    private SortingGroup mySortingGroup;

    [SerializeField]
    private float offset = 0.0f;

    private void Awake()
    {
        mySortingGroup = gameObject.GetComponent<SortingGroup>();
    }

    private void LateUpdate()
    {
        mySortingGroup.sortingOrder = (int)(sotringOrderBase - transform.position.y * 10 - offset);
        Destroy(this);
    }
}
