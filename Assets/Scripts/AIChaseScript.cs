using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AIChaseScript : MonoBehaviour
{
    public CharacterBehaviour behaviour;

    GameObject player;
    public float speed, speed2;
    public float distanceToAttack;
    public float minDistance;

    public float attackDelay = 1.8f;
    float nextAttackTime;

    private void Awake()
    {
        nextAttackTime = attackDelay;
        behaviour = GetComponent<CharacterBehaviour>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetComponent<CharacterBehaviour>().isDead) return;

        float disY = transform.position.y - player.transform.position.y;
        float disX = transform.position.x - player.transform.position.x;

        float moveX = disX < -minDistance ? 1 : disX > minDistance ? -1 : 0;
        float moveY = disY < -0.1 ? 1 : disY > 0.1 ? -1 : 0;

        if (nextAttackTime > 0) nextAttackTime -= Time.deltaTime;
        else
        {
            if (Mathf.Abs(disX) < distanceToAttack && Mathf.Abs(disY) < 0.3)
            {
                behaviour.Attack();
                nextAttackTime = attackDelay;
            }
        }

        behaviour.Move(moveX, moveY);
    }
}
