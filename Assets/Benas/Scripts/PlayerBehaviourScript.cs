using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{

    public int maxHealth;
    public int health;

    public HealthBarScript healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TakeDamageB(10);
        }
    }

    public void TakeDamageB(int dmg)
    {
        health -= dmg;
        healthBar.SetHealth(health);
    }
}
