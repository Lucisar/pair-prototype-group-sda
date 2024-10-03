using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    private float speed = 30f;
    private Rigidbody2D rb;
    private Vector3 mousePos;
    private Transform playerPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        // aiming w/ mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // get intended direction & velocity of projectile regardless of how close/far mouse is
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    void Update()
    {
        // Destroy the projectile if it becomes too far away from the player
        if (transform.position.x - playerPos.position.x > 10.0f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the projectile collides with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ++BrickText.numBricks;
            // Destroy both the projectile and the obstacle
            Destroy(collision.gameObject);
            Destroy(gameObject);
        } 
        else if (collision.gameObject.CompareTag("platforms")
            || collision.gameObject.CompareTag("Player")
            || collision.gameObject.CompareTag("RealBricks"))
        {
            Destroy(gameObject);
        }
    }
}