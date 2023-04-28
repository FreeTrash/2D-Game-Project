using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAIShooting : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behavior")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    [Header("Shooting")]
    public float ShootingRange;
    public GameObject Bullet;
    public Transform BulletParent;
    public float firerate = 5f;
    private float nextFireTime;
    private Transform player;

    public Rigidbody2D bulletPrefab;
    public float shootSpeed = 300;

    private bool playerInRange = false;
    private float lastAttackTime = 0f;
    private float fireRate = 0.5f; //how many bullets are fired/second
    private Transform Player = null;
    private Path path;
    private int currentWaypoint = 0;
    
    RaycastHit2D isGrounded;
    Seeker seeker;
    Rigidbody2D rb;

    //distanceFromPlayer < activateDistance
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }
    private void Update()
    {

        if (playerInRange)
        {
            //Rotate the enemy towards the player
            transform.rotation = Quaternion.LookRotation(player.position - transform.position, transform.up);

            if (Time.time - lastAttackTime >= 1f / fireRate)
            {
                shootBullet();
                lastAttackTime = Time.time;
            }
        }
        void shootBullet()
        {

            var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //Shoot the Bullet in the forward direction of the player
            projectile.velocity = transform.forward * shootSpeed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }
    

    private void FixedUpdate()
    {
      //  if (TargetInDistance() && followEnabled)
        {
         //   PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        // Reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        // See if colliding with anything
        Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);

        // Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        // Jump
        if (jumpEnabled && isGrounded)
        {
            if (direction.y > jumpNodeHeightRequirement)
            {
                rb.AddForce(Vector2.up * speed * jumpModifier);
            }
        }

        // Movement
        rb.AddForce(force);

        // Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Direction Graphics Handling
      //  if (directionLookEnabled)
        {
     //      if (rb.velocity.x > 0.000000005f)
            {
      //          transform.localScale = new Vector3( Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
       //         BulletParent.transform.Rotate(0f, 0f, 0f);
            }
      //      else if (rb.velocity.x < -0.000005f)
            {
         //       transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
         //       BulletParent.transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            player = other.transform;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            playerInRange = false;
            player = null;
        }
    }
    
}