using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer myRenderer;
    private int originalSortingOrder;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        originalSortingOrder = myRenderer.sortingOrder;     
    }

    private void changeOrder(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            if (transform.position.y > collision.transform.position.y)
                myRenderer.sortingOrder = collision.GetComponent<SpriteRenderer>().sortingOrder - originalSortingOrder;
            else
                myRenderer.sortingOrder = collision.GetComponent<SpriteRenderer>().sortingOrder + originalSortingOrder;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        changeOrder(collision);       
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        changeOrder(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        myRenderer.sortingOrder = originalSortingOrder;
    }



}
