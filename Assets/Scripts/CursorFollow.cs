using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour {

   

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
       
            //Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position = cursorPos;

            var pos = Input.mousePosition;
            pos.z = 10;
            pos = Camera.main.ScreenToWorldPoint(pos);
            transform.position = Vector3.Lerp(transform.position, pos, 30f * Time.deltaTime);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
