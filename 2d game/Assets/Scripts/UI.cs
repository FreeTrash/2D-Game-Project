using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject ObjectToActivateAndDeactivate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ObjectToActivateAndDeactivate.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ObjectToActivateAndDeactivate.SetActive(true);
        }



        //Contoller
        if (Input.GetButtonDown("PowerMode"))
        {
            ObjectToActivateAndDeactivate.SetActive(false);
        }

        if (Input.GetButtonDown("NormalMode"))
        {
            ObjectToActivateAndDeactivate.SetActive(true);
        }


    }
}
