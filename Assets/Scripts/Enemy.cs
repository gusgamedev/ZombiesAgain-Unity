using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    
    [HideInInspector]
    public Transform player;

    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    public int pickupChance;
    public GameObject[] pickups;

    public int healthPickupChance;
    public GameObject healthPickup;

    public GameObject explosion;
    public GameObject blood;

    private Animator anim;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {


        if (player != null)
        {         
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            anim.SetBool("front", transform.position.y > player.transform.position.y);
            

        }

    }

    public void TakeDamage (int amount) {
        health -= amount;
        if (health <= 0)
        {
            /* int randomNumber = Random.Range(0, 101);
             if (randomNumber < pickupChance)
             {
                 GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                 Instantiate(randomPickup, transform.position, transform.rotation);
             }

             int randHealth = Random.Range(0, 101);
             if (randHealth < healthPickupChance)
             {
                 Instantiate(healthPickup, transform.position, transform.rotation);
             }
             */
            Instantiate(blood, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }

    
}
