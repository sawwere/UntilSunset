using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class MainCameraScript : MonoBehaviour
{
    public Transform player;

    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private Camera camera;
    private float initZoom = 5f;
    private float targetZoom = 5f;
    private float zoomFactor = 3f;
    [SerializeField] private float zoomLerpSpeed = 10f;

    private void Awake()
    {
        camera = Camera.main;
        targetZoom = camera.orthographicSize;
    }

    private void LateUpdate()
    {
        CalculateNewPosition();
        //HandleZoom();
    }

    private void CalculateNewPosition()
    {
        Vector3 delta = Vector3.zero;
        Vector3 playerPosition = player.position;
        Vector3 cameraPosition = transform.position;

        float deltaX = playerPosition.x - cameraPosition.x;
        if (Abs(deltaX) > boundX)
        {
            if (cameraPosition.x < playerPosition.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = playerPosition.y - cameraPosition.y;
        if (Abs(deltaY) > boundY)
        {
            if (cameraPosition.y < playerPosition.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        HandleZoom();

        AdjustDelta(ref delta);

        transform.position = new Vector3(delta.x, delta.y, -10);
    }

    private void AdjustDelta(ref Vector3 delta)
    {
        Vector3 newPosition = transform.position;

        delta.x += newPosition.x;
        //delta.x = Max(delta.x, -11.5f * initZoom / targetZoom);
        //delta.x = Min(delta.x, 11.5f * initZoom / targetZoom);

        delta.y += newPosition.y;
        //delta.y = Max(delta.y, 0.0f);
        //delta.y = Min(delta.y, 10.0f);
    }

    private void HandleZoom()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 5f, 7f);
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
    }
}
