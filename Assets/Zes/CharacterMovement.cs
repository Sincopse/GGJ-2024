using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float hSpeed;
    public float vSpeed;
    private Rigidbody2D rb;

    private bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float hMove, float vMove, bool jump)
    {
        Vector2 targetVelocity = new Vector2(hMove * hSpeed, vMove * vSpeed);

        rb.MovePosition(rb.position + targetVelocity * Time.deltaTime);

        if (hMove > 0 && !facingRight || hMove < 0 && facingRight) Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
