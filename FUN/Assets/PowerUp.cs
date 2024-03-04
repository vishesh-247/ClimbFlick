using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public HealthBar healthBar;

    public PlayerMovement playerHealth;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            HealthRecover();
            Destroy(collision.gameObject);
            
        }
    
    }

    private void HealthRecover()
    {
        healthBar.UpdateHealth(10);    
        playerHealth.playerHealth+= 10; 

        if (playerHealth.playerHealth > 100)
        {
            playerHealth.playerHealth = 100;
        }
    }

}
