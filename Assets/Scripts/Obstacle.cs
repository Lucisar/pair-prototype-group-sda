using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // speed at which the obstacle moves
    private float moveSpeed = 7f;

    // Update is called once per frame
    void Update()
    {
        // move the obstacle to the left
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // destroy the obstacle if it goes off screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}