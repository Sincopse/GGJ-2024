using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public int maxHealth = 100;
    int health;

    public float hSpeed;
    public float vSpeed;
    bool canMove = true;

    public Animator animator;

    Rigidbody2D rb;

    bool facingRight = true; 

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    public void Move(float hMove, float vMove)
    {
        if (canMove)
        {
            animator.SetBool("isMoving", (hMove != 0 || vMove != 0));

            rb.velocity = new Vector2(hMove * hSpeed, vMove * vSpeed);
            if (hMove > 0 && !facingRight || hMove < 0 && facingRight) Flip();
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isMoving", false);
        }
    }

    public void Attack()
    {
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(attackRange, 0.2f), 0.0f, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<CharacterBehaviour>().TakeDamage();
            Debug.Log("Enemy hit!");
        }
    }

    public void TakeDamage()
    {
        health -= 50;
        //animator.SetTrigger("damaged");
    }

    public void Die()
    {
        canMove = false;
        animator.SetTrigger("die");
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireCube(attackPoint.position, new Vector2(attackRange, 0.2f));
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
