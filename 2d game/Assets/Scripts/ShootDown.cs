using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class ShootDown : MonoBehaviour
{
    public Transform shootdown;


    public Rigidbody2D rb;
    public float Force= 15;
    public float knockbackforceUp = 2;

    public KeyCode key;
    private TextMesh text;

    public GameObject BulletPrefab;


    public AudioClip JumpBoost; // The audio clip that will be played
    private AudioSource audioSource; // The audio source component

    //Ammo
    public int CurrentClipSize, MaxClipSize = 2;
    public float FireRate;
    public float NexShootTme;

    private void Start()
    {
     rb= GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        // Set the AudioClip to play
        audioSource.clip = JumpBoost;

        text = GetComponent<TextMesh>();
    }
    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Reload"))
        {
            reload();
        }


        float Boost = Input.GetAxis("JumpBoost");
        if (Boost != 0 && Time.time > NexShootTme && CurrentClipSize != 0)
        {

            NexShootTme = Time.time + FireRate;
            knockback();
            Shoot();

        }

        if (Input.GetButtonDown("Fire2") && CurrentClipSize != 0)
        {
            knockback();
            Shoot();
        }
    

        if (Input.GetButtonDown("Crouch") && Input.GetButtonDown("Fire1"))
        {
            //
        }

    }
    void knockback()
    {
        
       
            Vector2 BulletDirection = transform.up; 

            rb.AddForce(1.0f * BulletDirection * Force, ForceMode2D.Impulse);
        
       
    }

    public void Shoot()
    {


            Instantiate(BulletPrefab, shootdown.position, shootdown.rotation);
            CurrentClipSize--;

            Shake.Instance.ShakeCamera(5f, .1f);
            audioSource.PlayOneShot(JumpBoost);




    }
    public void reload()
    {
        int reloadAmount = MaxClipSize - CurrentClipSize;

        CurrentClipSize += reloadAmount;
    }



}
