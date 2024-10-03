using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // get mouse position
    private Vector3 mousePos;
    // [SerializeField] = When Unity serializes your scripts, it only serializes public fields
    // Force Unity to serialize a private field...
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject brickProjPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // aiming w/ mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // update the rotation of the aim indicator to point towards the mouse
        Vector3 rotation = mousePos - transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle);

        
        // shoot when 'W' key pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            Shoot();
        }
        // build when 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E) && BrickText.numBricks > 0)
        {
            --BrickText.numBricks;
            Build();
        }
    }

    void Shoot()
    {
        // instantiate a projectile at the fire point
        Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
    }
    
    void Build()
    {
        // instantiate a projectile at the fire point
        Instantiate(brickProjPrefab, firePoint.position, Quaternion.identity);

    }
}
