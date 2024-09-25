using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // speed
    private float moveSpeed = 7f;
    // jump
    private float jumpForce = 8f;
    // ground check
    private bool isGrounded;
    // [SerializeField] = When Unity serializes your scripts, it only serializes public fields
    // Force Unity to serialize a private field..
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // get the Rigidbody2D component for the player
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // so player moves constantly to right 
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    { 

        // check if player touching ground via 'GroundCheck'
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // jump when the space pressed AND the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    // for player to jump
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
