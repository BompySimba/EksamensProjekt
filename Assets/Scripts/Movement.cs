using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 4.0f;
    public float sprintSpeed = 8.0f;
    public float jumpPower = 1f;
    private bool isFaceRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetBool("IsJumping", !IsGrounded());
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
        Flip();
        if(horizontal != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        if (Input.GetButton("Sprint"))
        {
            rb.linearVelocity = new Vector2(horizontal * sprintSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }
        animator.SetFloat("xVelocity", Math.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }


   

    private void Flip()
    {
        if (isFaceRight && horizontal < 0f || !isFaceRight && horizontal > 0f)
        {
            isFaceRight = !isFaceRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
