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

    public int bulletDamage;   

    // Angle limit in degrees
    public float angleLimit = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;

        // Limit the shooting angle
        direction = LimitDirection(direction, angleLimit);

        FaceMouse();

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > readyForNextShot)
            {
                readyForNextShot = Time.time + 1 / fireRate;
                Shoot();

            }
        }
    }

    void FaceMouse()
    {
        Gun.transform.right = direction.normalized;
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D bulletRigidbody = BulletIns.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(BulletIns.transform.right * bulletSpeed);

        // Pass the bullet damage to the bullet script
        Player_Bullet bulletScript = BulletIns.GetComponent<Player_Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDamage(bulletDamage);
        }

        gunAnimator.SetTrigger("Shoot");
        CameraShaker.Instance.ShakeOnce(1.2f, 0.8f, 0.1f, 0.1f);
        Destroy(BulletIns, 4f);
    }

    // Limit direction to a certain angle range
    Vector2 LimitDirection(Vector2 direction, float angleLimit)
    {
        float angle = Vector2.Angle(Vector2.right, direction);
        if (angle > angleLimit)
        {
            if (direction.y < 0)
            {
                angle = -angleLimit;
            }
            else
            {
                angle = angleLimit;
            }
            direction.x = Mathf.Cos(angle * Mathf.Deg2Rad);
            direction.y = Mathf.Sin(angle * Mathf.Deg2Rad);
        }
        return direction;
    }
}
