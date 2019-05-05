using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject projectile;
    public GameObject muzzle;
    
    public float timeBetweenShots;

    private float shotTime;
    
  

    private void Update()
    {
        LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                GameObject bullet = Instantiate(muzzle, transform.position, transform.rotation) as GameObject;
                bullet.transform.parent = this.transform;

                //Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), transform.rotation);


                GameManager.instance.shake.ShakeCamera(0.3f, 0.1f);
                shotTime = Time.time + timeBetweenShots;
                GetComponent<AudioSource>().Play();
            }

        }
    }

    void LookAt(Vector3 targetPosition)
    {
        Vector2 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

}
