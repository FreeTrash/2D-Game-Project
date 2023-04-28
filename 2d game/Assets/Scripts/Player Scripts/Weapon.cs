using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class Weapon : MonoBehaviour
{
    public Transform FirePoint;


    public float FireRate = 1f;
    public float NexShootTme = 0f;
 
    public Rigidbody2D rb;
    public float knockbackforce = 10;
    public float knockbackforceUp = 2;
    public float ShakeMagnitude = 2f;
    
    public GameObject BulletPrefab;

    public float ShakePower = 2f;
    //private InputAction fire;

    [Header("Amount Of Force")]
    public float NormalForce = 5f;
    public float PowerForce = 15f;

  
    public AudioClip soundClip; // The audio clip that will be played
    private AudioSource audioSource; // The audio source component

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        // Set the AudioClip to play
        audioSource.clip = soundClip;

    }
    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetButtonDown("PowerMode"))
        {
            knockbackforce = PowerForce;
        }
        if (Input.GetButtonDown("NormalMode"))
        {
            knockbackforce = NormalForce;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            knockbackforce = PowerForce;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            knockbackforce = NormalForce;
        }



        if (Input.GetButtonDown("Fire1"))
        {
            NexShootTme = Time.time + FireRate;
            Shoot();

            knockback();
            audioSource.PlayOneShot(soundClip);
        }

        float Attack = Input.GetAxis("Attack");
        if (Attack != 0 && Time.time > NexShootTme)
        {

            NexShootTme = Time.time + FireRate;
            Shoot();

            knockback();
            audioSource.PlayOneShot(soundClip);




        }

        
    }
        void knockback()
    {

        Vector2 BulletDirection = transform.right;

        rb.AddForce(-1f * BulletDirection * knockbackforce, ForceMode2D.Impulse);
       
    }

    public void Shoot()
    {


        //Shooting Logic
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);

        Shake.Instance.ShakeCamera(ShakePower, .1f);
        audioSource.PlayOneShot(soundClip);



    }

}
