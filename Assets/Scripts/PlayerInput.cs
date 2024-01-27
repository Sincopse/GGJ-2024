using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public CharacterBehaviour characterBehaviour;

    public Animator animator;

    Vector2 movement;

    public float attackDelay = 1.8f;
    float nextAttackTime;

    private void Awake()
    {
        nextAttackTime = attackDelay;
        animator = GetComponent<Animator>();
        characterBehaviour = GetComponent<CharacterBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (nextAttackTime > 0) nextAttackTime -= Time.deltaTime;
        else
        {
            characterBehaviour.canMove = true;
            if (Input.GetMouseButtonDown(0))
            {
                characterBehaviour.Attack();
                nextAttackTime = attackDelay;
                characterBehaviour.canMove = false;
            }
        }
    }

    void FixedUpdate()
    {
        characterBehaviour.Move(movement.x, movement.y);
    }
}
