using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public float mousepos;
    public float playerpos;


    public bool facingRight = true;
    private bool facingFront = true;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform trans;

    private Vector2 moveAmount;

    public int health;
    public Slider healthBar;
    private float damageTime;
    private float timeBetweenHits = 0.3f;

    
    
   



    private void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       // trans = GetComponent<Transform>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        //Set animation
        SetAnimationPlayer(moveInput);

        healthBar.value = health;

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    private void SetAnimationPlayer(Vector2 moveInput)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // - transform.position;
        facingFront = (mousePosition.y < transform.position.y);

        if (mousePosition.x < transform.position.x)
            transform.localScale = new Vector2(-1, transform.localScale.y);
        else
            transform.localScale = new Vector2(1, transform.localScale.y);

        healthBar.transform.localScale = new Vector2(transform.localScale.x, healthBar.transform.localScale.y);


        anim.SetBool("front", facingFront);
        anim.SetBool("idle", moveInput == Vector2.zero);

        
    }

    public void TakeDamage(int damage)
    {
        if (damageTime <= Time.time)
        {
            if (health > 0)
                health -= damage;

            damageTime = Time.time + timeBetweenHits;
        }

    }

   


}
