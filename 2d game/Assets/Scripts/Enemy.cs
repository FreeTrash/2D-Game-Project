using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int Health = 100;

    public GameObject deathEffect;

    public AudioClip DeathSound; // The audio clip that will be played
    private AudioSource audioSource; // The audio source component


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = DeathSound;

    }
    public void TakeDamage( int damage)
    {
        Health -= damage;
        audioSource.PlayOneShot(DeathSound);

        if (Health <= 0)
        {
           
            Die();
            
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Shake.Instance.ShakeCamera(10f, .2f);
        audioSource.PlayOneShot(DeathSound);
    }
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
