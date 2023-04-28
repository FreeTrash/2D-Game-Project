using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float runspeed = 40f;



    public Rigidbody2D rb;
    public CharacterController2D controller;
    public Animator animator;
    private SpriteRenderer spriteRender;

    float horizontalMove = 0f;
  
    bool jump = false;
    bool crouch = false;

    public KeyCode key;
    private TextMesh text;
    PlayerInput playerInput;


    public static PlayerController Instance;



    private void Start()
    {
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        text = GetComponent<TextMesh>();
        PlayerController.Instance = this;

    }  
       
        
   void Update()
  {

          



            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;

            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }



   }

        void FixedUpdate()
   {
            controller.Move(horizontalMove * Time.deltaTime, crouch, jump);
            GetComponentInChildren<SpriteRenderer>().flipX = false;
           
                

            jump = false;

   }
    
    
        
    
}

