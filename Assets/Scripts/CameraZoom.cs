using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    private float zoomSpeedRef;

    public float dampTime = 0.2f;
    public float maxZoom = 6.5f;

    private float minZoom;

    private Transform aim;
    private Transform target;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        minZoom = cam.orthographicSize;

        aim = GameObject.FindGameObjectWithTag("Aim").GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Zoom();
    }

    private void Zoom()
    {
        // Find the required size based on the desired position and smoothly transition to that size.
        float newSize = ZoomValue();
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, newSize, ref zoomSpeedRef, dampTime);
    }

    private float ZoomValue()
    {
        float dist = Vector3.Distance(aim.position, target.position);
        float newSize = minZoom + (dist / 10f);

        if (newSize > maxZoom)
            newSize = maxZoom;
        else if (newSize < minZoom)
            newSize = minZoom;

        return newSize;
    }
}
