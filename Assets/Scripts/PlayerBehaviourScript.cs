using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


public class PlayerBehaviourScript : MonoBehaviour
{

    public int maxHealth;
    public int health;

    public Sprite Smile;
    public Sprite Ok;
    public Sprite Neutral;
    public Sprite Sad;

    public Image Emoji;

    public HealthBarScript healthBar;
    // Start is called before the first frame update
    void Start()
    {
        SetHealthToMax();
        //healthBar.SetMaxHealth(maxHealth);

    }

    void SetHealthToMax()
    {
        health = maxHealth;
        Emoji = GetComponent<Image>();
        Emoji.sprite = Smile;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetHealthToMax();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamageB(10);
            Debug.Log("Hello: " + health);
        }
        
        if (health > 75 && health <= 100)
        {
            Emoji = GetComponent<Image>();
            Emoji.sprite = Smile;
        }
        else if (health > 50 && health < 75)
        {
            Emoji = GetComponent<Image>();
            Emoji.sprite = Ok;
        }
        else if (health > 25 && health < 50)
        {
            Emoji = GetComponent<Image>();
            Emoji.sprite = Neutral;
        }
        else if (health >= 0 && health < 25)
        {
            Emoji = GetComponent<Image>();
            Emoji.sprite = Sad;
        }
    }

    public void TakeDamageB(int dmg)
    {
        health -= dmg;
        healthBar.SetHealth(health);
    }
}
