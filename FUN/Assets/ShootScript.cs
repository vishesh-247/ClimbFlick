using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class ShootScript : MonoBehaviour
{
    public Transform Gun;
    Vector2 direction;
    public GameObject bullet;   
    public float bulletSpeed;

    public Transform shootPoint;

    public float fireRate;
    float readyForNextShot;

    public Animator gunAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);  
        direction= mousePos - (Vector2)Gun.position;
        FaceMouse();    

        if(Input.GetMouseButtonDown(0))
        {
            if(Time.time > readyForNextShot)
            {
                readyForNextShot= Time.time + 1/fireRate;
                Shoot();
            } 
            
        }
        
    }
    void FaceMouse()
    {
        Gun.transform.right= direction;

    }

    void Shoot()
    {
       GameObject BulletIns= Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * bulletSpeed);
        gunAnimator.SetTrigger("Shoot");
        CameraShaker.Instance.ShakeOnce(1.2f, 0.8f, 0.1f, 0.1f);   
        Destroy(BulletIns, 4f); 

        
    }
}
