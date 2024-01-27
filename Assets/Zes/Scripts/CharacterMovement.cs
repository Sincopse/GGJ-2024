using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float hSpeed;
    public float vSpeed;

    public Animator animator;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float hMove, float vMove)
    {
        animator.SetBool("isMoving", (hMove != 0 || vMove != 0));

        rb.velocity = new Vector2(hMove * hSpeed, vMove * vSpeed);
        if (hMove > 0 && !facingRight || hMove < 0 && facingRight) Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
