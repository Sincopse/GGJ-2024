using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public CharacterBehaviour characterBehaviour;

    Vector2 movement;

    private void Awake()
    {
        characterBehaviour = GetComponent<CharacterBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            characterBehaviour.Attack();
        }
    }

    void FixedUpdate()
    {
        characterBehaviour.Move(movement.x, movement.y);
    }
}
