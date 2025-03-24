using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MoveSpeed, JumpForce;
    private float x, y;
    public Animator animator;

    public LayerMask WhatIsGround;
    private bool Grounded;
    public float CheckRadius;
    public Transform GroundCheck;

    public float JumpTime;
    private float TimeLeft;
    private bool Jumping;
    private int jumpsLeft;

    private bool facingRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * MoveSpeed, rb.velocity.y);
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatIsGround);

        animator.SetFloat("speed", Mathf.Abs(x));
        animator.SetBool("jumping", !Grounded);

        if (Grounded)
        {
            land();
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && Grounded && jumpsLeft > 0)
        {
            TimeLeft = JumpTime;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            Jumping = true;
            jumpsLeft -= 1;
        }

        if (Jumping && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            if (TimeLeft > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                Jumping = false;
            }
        }

        if ((facingRight == true) && (x < 0))
        {
            flip();
        }

        else if ((facingRight == false) && (x > 0))
        {
            flip();
        }
    

    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void land()
    {
        jumpsLeft = 2;
    }
}
