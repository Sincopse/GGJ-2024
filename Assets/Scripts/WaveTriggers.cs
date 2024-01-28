using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTriggers : MonoBehaviour
{
    List<Transform> childs = new List<Transform>();

    void Start()
    {
        FindEveryChild(gameObject.transform);
    }

    private void Update()
    {
        for (int i = 0; i < childs.Count; i++)
        {
            if (childs[i].GetComponent<SpawnEnemy>().target.GetComponent<CharacterBehaviour>().isDead)
            {
                Debug.Log("Balls");
            }
        }
    }

    public void FindEveryChild(Transform parent)
    {
        int count = parent.childCount;
        for (int i = 0; i < count; i++)
        {
            childs.Add(parent.GetChild(i));
        }
    }

    void StartBattle()
    {
        Debug.Log("Battle Started");

        for (int i = 0; i < childs.Count; i++)
        {
            childs[i].GetComponent<SpawnEnemy>().Spawn();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Player inside trigger!");
            StartBattle();
            Destroy(gameObject);
        }
    }
}
