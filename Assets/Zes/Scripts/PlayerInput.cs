using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public CharacterBehaviour characterBehaviour;

    public Animator animator;

    Vector2 movement;

    public int attackDamage = 40;

    public float attackRate = 1.8f;
    float nextAttackTime = 0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterBehaviour = GetComponent<CharacterBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                characterBehaviour.Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void FixedUpdate()
    {
        characterBehaviour.Move(movement.x, movement.y);
    }
}
