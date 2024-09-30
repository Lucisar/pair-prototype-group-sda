using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class BrickProjectile : MonoBehaviour
{
    private float speed = 20f;
    private Rigidbody2D rb;
    private Transform playerPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Move the projectile to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Destroy the projectile if it becomes too far away from player
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
            Destroy(gameObject);
        }
    }
}