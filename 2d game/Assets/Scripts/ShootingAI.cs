using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ShootingAI : MonoBehaviour
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

    private Path path;
    private int currentWaypoint = 0;
    RaycastHit2D isGrounded;
    Seeker seeker;
    Rigidbody2D rb;

    [Header("Shooting Logic")]
    public float StoppingDistance;
    public float TimeBtShots;
    public float StartTimeBetweenShots;
    public GameObject Bullet;
    
    
    [Header("Flipping logic")]
    public Transform bulletparent;
    public bool facingRight;
    public bool Flip;

    public float attackingDistance = 20f;
    public void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
        target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
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
        if (directionLookEnabled)
        {
            if (rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                
            }
            else if (rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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
    private void Update()
    {

        float DistanceFromPlayer = Vector2.Distance(transform.position, target.position);
       
    

         //Make Enemy Face Towards Player

        Vector3 scale = transform.localScale;

        if (target.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (Flip ? -1 : 1);
        }
        
        transform.localScale = scale * (Flip ? -1 : 1); ;

        // Flip Bullet Parent
        Vector3 Scale = bulletparent.localScale;

        if (target.position.x > bulletparent.position.x)
        {
            bulletparent.Rotate(0, 180, 0);
        }
        else if ((target.position.x < bulletparent.position.x))
        {
            bulletparent.Rotate(0, 180, 0);
        }

       

        // Fire rate

        if (TimeBtShots <= 0 && DistanceFromPlayer < attackingDistance)
        {
            Instantiate(Bullet, bulletparent.transform.position, bulletparent.rotation);
            TimeBtShots = StartTimeBetweenShots;
            
        }
        else
        {
            TimeBtShots -= Time.deltaTime;
        }
        
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, activateDistance);
        Gizmos.DrawWireSphere(transform.position, attackingDistance);
    }
}