using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    void FixedUpdate()
    {
        characterBehaviour.Move(movement.x, movement.y);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
