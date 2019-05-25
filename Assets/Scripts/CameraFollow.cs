using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Transform aim;
    
	public float speed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float maxCamDistance;

    float clampedX;
    float clampedY;


    private void Start()
    {
        transform.position = target.position;
    }

    private void LateUpdate()
    {

        if (target != null)
        {
            float dist = Vector3.Distance(aim.position, target.position);

            if (dist < maxCamDistance)
            {
                Vector2 cam = aim.position;
                clampedX = Mathf.Clamp((target.position.x + cam.x) / 2, minX, maxX);
                clampedY = Mathf.Clamp((target.position.y + cam.y) / 2, minY, maxY);
            }
            
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed * Time.deltaTime);
        }
    }
}
