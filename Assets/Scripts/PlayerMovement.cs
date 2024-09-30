using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // speed
    private float moveSpeed = 7f;
    // jump
    private float jumpForce = 13f;
    // ground check
    private bool isGrounded;
    // track gravity state
    private bool isFlipped = false;
    // [SerializeField] = When Unity serializes your scripts, it only serializes public fields
    // Force Unity to serialize a private field...
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject brickProjPrefab;

    [SerializeField] private GameObject levelCompletePanel;
    // Start is called before the first frame update
    void Start()
    {
        // get the Rigidbody2D component for the player
        rb = GetComponent<Rigidbody2D>();
        levelCompletePanel.SetActive(false);
    }

    void FixedUpdate()
    {
        // so player moves constantly to right 
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    // Update is called once per frame
    void LateUpdate()
    { 

        // check if player touching ground via 'GroundCheck'
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // jump when the 'space' pressed AND the player is grounded (no double jumping)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        // shoot when 'D' key pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.B) && BrickText.numBricks > 0)
        {
            --BrickText.numBricks;
            Build();
        }
    }

    // for player to jump
    void Jump()
    {
        // determine the jump direction based on FlipGravity Funct below
        float jumpDirection = isFlipped ? -jumpForce : jumpForce;
        // finish jump direction for player
        rb.velocity = new Vector2(rb.velocity.x, jumpDirection);
    }
    
    void Shoot()
    {
        // Instantiate a projectile at the fire point
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        // OnCollisionEnter2 = Sent when an incoming collider makes contact with this object's collider
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // handle collision with obstacle (e.g., end game, reduce health, etc.)
            Debug.Log("Collided with obstacle!");
        }
        
        if (collision.gameObject.CompareTag("EndGoal"))
        {
            LevelComplete();
        }
        
        if (collision.gameObject.CompareTag("spikes"))
        {
            //restart the game
            Debug.Log("Collided with spikes!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }

    void Build()
    {
        Instantiate(brickProjPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GravityPlatform"))
        {
            FlipGravity();
        }
    }

    // flip gravity of player based wehn colliding with platform 
    void FlipGravity()
    {
        // change bool of gravity on/off
        isFlipped = !isFlipped;
        // reverse direction 
        rb.gravityScale *= -1;
        // flip player
        transform.Rotate(180f, 0f, 0f);
    }

    // detect level completed
    void LevelComplete()
    {
        Debug.Log("Level Complete!");
        // make sure to add scene in File->Build Settings->Add Open Scenes when in
        // in the new scene you want to add 
        //pause the game
        Time.timeScale = 0;
        levelCompletePanel.SetActive(true);
    }
    public void OnLevelCompleteButtonClicked()
    {
        // 加载新场景
        SceneManager.LoadScene("BT_Prototype");
        Time.timeScale = 1;
    }
    
    public void OnQuitButtonClicked()
    {
        // 退出游戏
        Application.Quit();
    }
}
