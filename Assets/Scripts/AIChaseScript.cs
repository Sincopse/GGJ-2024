using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIChaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float speed, speed2;
    private float distance;
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
        if (distance < 3 && (transform.position.y - player.transform.position.y) < 0.1)
        {
            //beat his ass
            

        }
    }
}
