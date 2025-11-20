using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float horizontal;
    private float vertical;
    private bool facingRight = true;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator an;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        manageSprite();
    }
    private void FixedUpdate()
    {
        if (horizontal == 0 || vertical == 0)
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        else
        {
            float diagonalSpeed =  speed / Mathf.Sqrt(speed * speed * 2);
            rb.velocity = new Vector2(horizontal * diagonalSpeed, vertical * diagonalSpeed);
        }

            
    }
    void manageSprite()
    {
        if (facingRight && horizontal == -1)
        {
            sr.flipX = true;
            facingRight = false;
        }
        else if (!facingRight && horizontal == 1)
        {
            sr.flipX = false;
            facingRight = true;
        }
        if(horizontal != 0 || vertical != 0)
        {
            an.SetBool("moving", true);
        }
        else
        {
            an.SetBool("moving", false);
        }

    }
}
