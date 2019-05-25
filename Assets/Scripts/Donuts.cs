using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donuts : MonoBehaviour
{

    private SpriteRenderer sprite;
    public bool donutIsVisible;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        donutIsVisible = sprite.isVisible;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Player"))
        {
            SpawnManager.instance.donutSpawner.SpawnDonut();
            collision.GetComponent<Player>().PlayFx(collision.GetComponent<Player>().donutFx);

            Destroy(gameObject);
        }
    }

    

}
