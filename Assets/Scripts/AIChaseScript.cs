using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIChaseScript : MonoBehaviour
{
    public CharacterBehaviour characterBehaviour;

    public GameObject player;
    public float speed, speed2;
    private float distance;

    public float attackDelay = 1.8f;
    float nextAttackTime;

    private void Awake()
    {
        nextAttackTime = attackDelay;
        characterBehaviour = GetComponent<CharacterBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 disY = new Vector2(this.transform.position.x, player.transform.position.y);
        transform.position = Vector2.MoveTowards(this.transform.position, disY, speed2 * Time.deltaTime);

        if (distance > 3)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (nextAttackTime > 0) nextAttackTime -= Time.deltaTime;
        else
        {
            if (distance < 3 && (transform.position.y - player.transform.position.y) < 0.1)
            {
                characterBehaviour.Attack();
                nextAttackTime = attackDelay;
            }
        }
    }
}
