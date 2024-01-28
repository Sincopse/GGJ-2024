using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCalendarScript : MonoBehaviour
{
    // Start is called before the first frame update
  
    void Awake()
    {
        gameObject.SetActive(true);
        Invoke("Unactive", 4.5f);

    }
    private void Unactive()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
