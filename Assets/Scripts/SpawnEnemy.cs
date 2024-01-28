using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject target;

    public void Spawn()
    {
        Instantiate(target, transform.position, Quaternion.identity);
    }
}
