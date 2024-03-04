using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    private int damage;
    private bool hasDamaged = false; // Flag to track if damage has been applied

    // Set the damage value for the bullet
    public void SetDamage(int value)
    {
        damage = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasDamaged && collision.CompareTag("Enemy")) // Check if damage has been applied and tag is correct
        {
            // Apply damage to the enemy
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Set the flag to true to prevent multiple damage applications
            hasDamaged = true;

            // Destroy the bullet upon hitting the enemy
            Destroy(gameObject);
        }
    }
}
