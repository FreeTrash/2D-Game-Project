using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_2 : MonoBehaviour
{

    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        Object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Object.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Object.SetActive(true);
        }
       
        
        
        //Contoller
        
        if (Input.GetButtonDown("NormalMode"))
        {
            Object.SetActive(false);
        }

        if (Input.GetButtonDown("PowerMode"))
        {
            Object.SetActive(true);
        }

    }
}
