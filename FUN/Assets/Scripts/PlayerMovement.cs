using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private float _vertical;
    public float climbSpeed;
    private bool _isClimbing;

    public int playerHealth;
    
    private HashSet<GameObject> rope = new HashSet<GameObject>();

    public GameObject gameOverScreen;

    public AudioManager audioManager;   

 

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        playerHealth = 100;
       
    }

   
    private void FixedUpdate()
    {

        if(_isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity= new Vector2(rb.velocity.x, _vertical * climbSpeed);    

        }
        else
        {
            rb.gravityScale = 4f;
        }
            moveInput = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {

        _vertical= Input.GetAxisRaw("Vertical");

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

        if(rope.Count > 0 && Mathf.Abs(_vertical)>0)
        {
            _isClimbing = true;
           
        }
        else if(rope.Count <= 0 )
        {
            _isClimbing = false;
            
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

        if(other.CompareTag("Rope"))
        {
            rope.Add(other.gameObject); 
            
        }
        if (other.CompareTag("Lava"))
        {

           

            GameOver(); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Rope"))
        {
            rope.Remove(other.gameObject);  

        }

    }

    void GameOver()
    {
        Destroy(gameObject);    
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;


    }

    void Respawn()
    {
        // Teleport the player to the respawn point

        
        transform.position = gameManager.respawnPoint.position;

    }
}
