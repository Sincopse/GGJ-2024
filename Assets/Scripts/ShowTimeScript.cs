using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShowTimeScript : MonoBehaviour
{
    GameObject gameobjectT;
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
