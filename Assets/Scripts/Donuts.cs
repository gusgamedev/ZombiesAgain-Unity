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
        Debug.Log(collision.tag);

        if (collision.CompareTag("Player"))
        {
            GameManager.instance.donutSpawner.SpawnDonut();

            Destroy(gameObject);
        }
    }

    

}
