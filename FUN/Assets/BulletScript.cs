using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
     


    private float timer;

    

    

    


    private void Start()
    {
           
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot=Mathf.Atan2(-direction.y,-direction.x)*Mathf.Rad2Deg; 
        transform.rotation=Quaternion.Euler(0,0,rot+90);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            

            other.gameObject.GetComponent<HealthBar>().UpdateHealth(-10);
            other.GetComponent<PlayerMovement>().playerHealth -= 10;


            Destroy(gameObject);
        }
    }


}
