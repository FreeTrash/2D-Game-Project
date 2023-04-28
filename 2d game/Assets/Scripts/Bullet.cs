using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ShootDown shoot;

    public float speed = 20f;

    public Rigidbody2D rb;

    public int Damage = 20;

    public GameObject ImpactEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        Enemy enemy = HitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }
        Destroy(gameObject);
        
        Instantiate(ImpactEffect, transform.position, transform.rotation);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
