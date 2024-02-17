using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    public HealthBar healthBar;  

    public PlayerMovement playerHealth;
    private Animator anim;

    
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>(); 
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            anim.Play("Death_Anim");

            Damage();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            anim.Play("Idle_Anim");
        }
    }

    private void Damage()
    {
        healthBar.UpdateHealth(-10);
       // anim.SetTrigger("death");

        playerHealth.playerHealth -= 10;    
        if(playerHealth.playerHealth <= 0)
        {
            
        
            Die();
        }   
        
        
    }
    private void Die()
    {
        Destroy(gameObject);    
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   
}
