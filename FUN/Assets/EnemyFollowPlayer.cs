using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    private Transform player;
    public float lineOfSight;
    public float shootingRange;

    public GameObject bullet;
    public GameObject bulletPoint;

    public float fireRate = 1f;
    private float nextFireTime;

    private SpriteRenderer spriteRenderer; // Reference to the sprite renderer component

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer component
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        // Move towards the player if within line of sight but not within shooting range
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            // Flip the sprite if moving towards the left
            if (player.position.x < transform.position.x)
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;
        }
        // Shoot at the player if within shooting range
        else if (distanceFromPlayer <= shootingRange && Time.time > nextFireTime)
        {
            Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    // Draw the line of sight and shooting range in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
