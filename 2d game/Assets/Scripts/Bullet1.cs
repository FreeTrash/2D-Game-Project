using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public ShootDown shoot;

    public float speed = 20f;


    public AudioClip ImpactSound; // The audio clip that will be played
    private AudioSource audioSource; // The audio source component


    public Rigidbody2D rb;

    public int Damage = 20;

    public GameObject ImpactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        audioSource = GetComponent<AudioSource>();

        // Set the AudioClip to play
        audioSource.clip = ImpactSound;

    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        PlayerDie Player = HitInfo.GetComponent<PlayerDie>();
        if (Player != null)
        {
            Player.TakeDamage(Damage);
        }
        Destroy(gameObject);
        
        Instantiate(ImpactEffect, transform.position, transform.rotation);
        audioSource.PlayOneShot(ImpactSound);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
