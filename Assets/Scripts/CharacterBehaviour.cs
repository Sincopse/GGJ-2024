using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public int maxHealth = 100;
    int health;

    public bool isDead = false;

    public float hSpeed;
    public float vSpeed;

    bool canMove = true;

    public Animator animator;

    public Rigidbody2D rb;

    bool facingRight = true;

    public int attackDamage = 40;
    public Transform attackPoint;
    public float attackRangeH = 0.2f;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public float attackDelay = 1.8f;
    float nextAttackTime = 0;

    public AudioSource attackSound;
    public AudioSource damageSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    private void Update()
    {
        if (isDead) return;

        // Ataack cooldown
        if (nextAttackTime > -attackDelay + .3) nextAttackTime -= Time.deltaTime;
        if (nextAttackTime <= 0.2) canMove = true;
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

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void Attack()
    {
        if (nextAttackTime <= 0 && !isDead)
        {
            nextAttackTime += attackDelay;
            canMove = false;
            animator.SetTrigger("attack");
            attackSound.Play();

            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(attackRange, attackRangeH), 0.0f, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<CharacterBehaviour>().TakeDamage(attackDamage);
                Debug.Log("Enemy hit!");
            }
        }
    }

    void TakeDamage(int damage)
    {
        nextAttackTime = attackDelay;
        damageSound.Play();
        animator.SetTrigger("damaged");
        health -= damage;

        if (health <= 0) Die();
    }

    void Die()
    {
        isDead = true;
        canMove = false;
        if (gameObject.layer == 3)
        {
            Destroy(gameObject);
            return;
        }
        animator.SetBool("dead", true);
    }

    void OnDrawGizmos()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireCube(attackPoint.position, new Vector2(attackRange, attackRangeH));
    }
}
