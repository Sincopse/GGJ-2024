using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShowTimeScript : MonoBehaviour
{
    public GameObject GameObject;
    public float repeatTime = 0.5f;
    private void Start()
    {
        InvokeRepeating("ToggleVisibilityTime",0.5f, repeatTime);
    }
    public void ToggleVisibilityTime()
    {
        if (gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(true);
        }
        else if (gameObject.activeInHierarchy == true)
        {
            gameObject.SetActive(false);
        }

    }

}
