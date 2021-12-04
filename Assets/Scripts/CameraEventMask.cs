using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraEventMask : MonoBehaviour
{
    [SerializeField]
    private LayerMask cameraEventMask;

    void Awake()
    {
        GetComponent<Camera>().eventMask = cameraEventMask;
    }
}
