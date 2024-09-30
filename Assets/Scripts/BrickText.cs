using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrickText : MonoBehaviour
{
    public static int numBricks = 0;
    [SerializeField] private TMP_Text brickText;
    // Start is called before the first frame update
    void Start()
    {
        numBricks = 0;
        brickText.text = "Bricks: 0";
    }

    // Update is called once per frame
    void Update()
    {
        brickText.text = "Bricks: " + numBricks;
    }
}
