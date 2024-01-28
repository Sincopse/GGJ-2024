using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    //private float lenght, startpos;
    //public GameObject cam;
    //public float parallaxEffect;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    startpos = transform.position.x;
    //    lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    float distance = (cam.transform.position.x * parallaxEffect);

    //    transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    //}

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.position += new Vector3(-5 * Time.deltaTime, 0);

        if (cam.transform.position.x - transform.position.x < -21.5)
        {
            transform.position = new Vector3(21.5f, transform.position.y);
        }
    }
}
