using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AIChaseScript : MonoBehaviour
{
    public CharacterBehaviour behaviour;

    GameObject player;
    public float speed, speed2;
    private float distance;

    public float attackDelay = 1.8f;
    float nextAttackTime;

    private void Awake()
    {
        nextAttackTime = attackDelay;
        behaviour = GetComponent<CharacterBehaviour>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        //Vector2 disY = new Vector2(this.transform.position.x, player.transform.position.y);

        float disY = transform.position.y - player.transform.position.y;
        float disX = transform.position.x - player.transform.position.x;

        float moveY = 0.0f;
        float moveX = 0.0f;

        if (Mathf.Abs(disY) > 0.1)
        {
            moveY = disY < -0.1 ? 1 : disY > 0.1 ? -1 : 0;
        }
        else if (Mathf.Abs(disX) > 2)
        {
            moveX = disX < -0.1 ? 1 : disX > 0.1 ? -1 : 0;
        }
        else behaviour.Attack();


        if (nextAttackTime > 0) nextAttackTime -= Time.deltaTime;
        else
        {
            if (distance < 3 && (transform.position.y - player.transform.position.y) < 0.1)
            {
                behaviour.Attack();
                nextAttackTime = attackDelay;
            }
        }

        behaviour.Move(moveX, moveY);

        //transform.position = Vector2.MoveTowards(this.transform.position, disY, speed2 * Time.deltaTime);

        //Vector3 dir = (player.transform.position - behaviour.rb.transform.position).normalized;
        //if (Vector3.Distance(player.transform.position, behaviour.rb.transform.position) > .5)
        //{
        //    behaviour.rb.MovePosition(behaviour.rb.transform.position + dir * speed * Time.fixedDeltaTime);
        //    //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //}
        //if (nextAttackTime > 0) nextAttackTime -= Time.deltaTime;
        //else
        //{
        //    if (distance < 3 && (transform.position.y - player.transform.position.y) < 0.1)
        //    {
        //        behaviour.Attack();
        //        nextAttackTime = attackDelay;
        //    }
        //}
    }

    //void FixedUpdate()
    //{
    //    //Find direction
    //    Vector3 dir = (player.transform.position - characterBehaviour.rb.transform.position).normalized;
    //    //Check if we need to follow object then do so 
    //    if (Vector3.Distance(player.transform.position, characterBehaviour.rb.transform.position) > .5)
    //    {
    //        characterBehaviour.rb.MovePosition(characterBehaviour.rb.transform.position + dir * speed * Time.fixedDeltaTime);
    //    }
    //}
}
