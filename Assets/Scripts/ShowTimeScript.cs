using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTimeScript : MonoBehaviour
{
    GameObject gameobjectT;
    // Start is called before the first frame update
    public void ToggleVisibility()
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
