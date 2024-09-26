using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Projectile : MonoBehaviour
{
    private float speed = 20f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
    }

    void Update()
    {
        // Move the projectile to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Destroy the projectile if it goes off screen

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the projectile collides with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Destroy both the projectile and the obstacle
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}