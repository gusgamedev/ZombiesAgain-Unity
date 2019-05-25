using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject projectile;
    public GameObject muzzle;

    private Transform aim;
    private CameraShake shake;

    public float timeBetweenShots;

    private float shotTime;
    
    private void Awake()
    {
        aim = GameObject.FindGameObjectWithTag("Aim").transform;
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }


    private void Update()
    {        
         LookAt(aim.position);
        
        if (Input.GetMouseButton(0) || Input.GetButton("Fire1"))
        {
            if (Time.time >= shotTime)
            {
                GameObject bullet = Instantiate(muzzle, transform.position, transform.rotation) as GameObject;
                bullet.transform.parent = this.transform;

                Instantiate(projectile, transform.position, transform.rotation);
                
                shake.ShakeCamera(0.3f, 0.1f);
                shotTime = Time.time + timeBetweenShots;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    void LookAt(Vector3 targetPosition)
    {
        transform.right = targetPosition - transform.position;
    }


}
