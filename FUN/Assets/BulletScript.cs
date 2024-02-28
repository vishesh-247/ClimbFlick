using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed; 
    Rigidbody2D bulletRB; 
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>(); 
        target = GameObject.FindGameObjectWithTag("Player");

        Vector2 moveDirection = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 2f);    
        

        
    }

   
}
