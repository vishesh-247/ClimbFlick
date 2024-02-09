using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;    

    private bool isGrounded;    
    public Transform feetPos;   
    public float checkRadius;
    public LayerMask whatIsGround;  
    public float jumpForce; 

    private float jumpTimeCounter;  
    public float jumpTime;

    private bool isJumping;

    private GameManager gameManager;

    public Animator anim;

 

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
       
    }

   
    private void FixedUpdate()
    {
            moveInput = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {

        if(moveInput != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }   
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {   
            isJumping = true;
            jumpTimeCounter = jumpTime; 
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space ) && isJumping==true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
           
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim. SetBool("isJumping", false);  
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJumping", true);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lava"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Teleport the player to the respawn point
        
        transform.position = gameManager.respawnPoint.position;
    }
}
