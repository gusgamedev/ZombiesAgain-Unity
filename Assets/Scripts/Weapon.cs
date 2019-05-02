using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject projectile;
    public GameObject muzzle;
    
    public float timeBetweenShots;

    private float shotTime;
    public CameraShake shake;
  

    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;


        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                GameObject bullet = Instantiate(muzzle, transform.position, transform.rotation) as GameObject;
                bullet.transform.parent = this.transform;

                Instantiate(projectile, transform.position, transform.rotation);

                shake.ShakeCamera(0.3f);
                shotTime = Time.time + timeBetweenShots;
                GetComponent<AudioSource>().Play();
            }

        }


    }

}
