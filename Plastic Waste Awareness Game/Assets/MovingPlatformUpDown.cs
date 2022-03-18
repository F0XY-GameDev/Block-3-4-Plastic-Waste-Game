using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformUpDown : MonoBehaviour
{

    public Rigidbody rb;

    Vector3 startPosition;
    Vector3 endPosition;
    Vector3 currentPosition;
    public bool goingUp;
    public float speedMult;
    public float upDistance;
    public float downDistance;

    private void Start()
    {
        startPosition.y = rb.position.y - downDistance;
        endPosition.y = rb.position.y + upDistance;
    }

    private void Update()
    {
        currentPosition = rb.position;
        if (currentPosition.y >= startPosition.y)
        {
            goingUp = true;
        }
        if (currentPosition.y >= endPosition.y)
        {
            goingUp = false;
        }
        if (goingUp)
            rb.AddForce(Vector3.up * speedMult, ForceMode.Force);
        else rb.AddForce(Vector3.down * speedMult, ForceMode.Force);

    }
}
