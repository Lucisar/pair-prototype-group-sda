using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private float smoothSpeed = 0.125f;
    // so when player jumps camera does not follow...
    private float fixedYPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (fixedYPos == 0)
        {
            fixedYPos = transform.position.y;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // get pos of camera w/ offset
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, fixedYPos + offset.y, offset.z);
        // smoothly interpolation between current pos and desired offset pos
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // finally update 
        transform.position = smoothedPosition;
    }
}
