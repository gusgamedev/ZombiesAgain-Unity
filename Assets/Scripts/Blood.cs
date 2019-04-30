using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public Sprite[] sprites;

    public float lifeTime = 3f;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        
        Destroy(this.gameObject, lifeTime);
    }

    
}
