using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    public float limitX;
    public float offsetY;
    public float speed;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(transform.position.x - player.transform.position.x > limitX ? player.transform.position.x
                                   : transform.position.x - player.transform.position.x < -limitX ? player.transform.position.x
                                   : transform.position.x, player.transform.position.y > 4 ? player.transform.position.y : offsetY, -10);

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }
}
