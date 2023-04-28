using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class GunAim : MonoBehaviour

{
    private Transform AimTransform;
    private SpriteRenderer spriteRender;
    

    public float offset;

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
       // AimTransform = transform.Find("Aim");
    }

    private void Update()
    {

        
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
       
        
         //Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

       // Vector3 aimdirection = (mousePosition - transform.position).normalized;
       // float angle = Mathf.Atan2(aimdirection.y, aimdirection.x) * Mathf.Rad2Deg;
        //AimTransform.eulerAngles = new Vector3(0,0, angle);
       // Debug.Log(angle);

        if (rotZ < 89 && rotZ > -89)
        {
            Debug.Log("facing Right");
            spriteRender.flipY = false;
        }
        else
        {
            Debug.Log("facing left");
            spriteRender.flipY = true;
        }


     //  if (rotZ < 140 && rotZ > -140)
        {
            Debug.Log("facing Right");
            spriteRender.flipX = false;
        }
   //   else
        {
            Debug.Log("facing left");
            spriteRender.flipX = true;
        }
       
        
        
    }

}
