using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


public class PlayerBehaviourScript : MonoBehaviour
{

    public int maxHealth;
    public int hp;

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
        hp = maxHealth;
        Emoji = GetComponent<Image>();
        Emoji.sprite = Smile;
    }
    // Update is called once per frame
    public void UpdateEmoji(int hp)
    {   
        if (hp > 75 && hp <= 100)
        {
            Emoji.color = Color.white;
            Emoji = GetComponent<Image>();
            Emoji.sprite = Smile;
        }
        else if (hp > 50 && hp < 75)
        {
            Emoji = GetComponent<Image>();
            Emoji.sprite = Ok;
        }
        else if (hp > 25 && hp < 50)
        {
            Emoji = GetComponent<Image>();
            Emoji.sprite = Neutral;
        }
        else if (hp > 0 && hp < 25)
        {
            Emoji = GetComponent<Image>();
            Emoji.sprite = Sad;
        }
        else if(hp == 0)
        {
            Emoji.color = Color.red;
        }
    }

    public void TakeDamageB(int health)
    {
        hp = health;
        healthBar.SetHealth(hp);
    }
}
