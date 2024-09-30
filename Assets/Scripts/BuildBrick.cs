using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBrick : MonoBehaviour
{
    [SerializeField] GameObject realBrick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bricks"))
        {
            Destroy(collision.gameObject);
            realBrick.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
