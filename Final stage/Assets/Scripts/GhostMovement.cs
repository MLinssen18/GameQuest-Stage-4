using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    int movementMode;
    Vector3 movementDirection;

    public float velocity;
    public float speedX;
    public float speedZ;
    public float transitionTime;
    float remainingTime;
    bool up;
    bool forceApplied;

    void Start()
    {
        remainingTime = transitionTime;
        up = true;
        forceApplied = true;

        movementMode = Random.Range(0, 8);
        if(movementMode == 0)
        {
            movementDirection = new Vector3(speedX, 0, speedZ);
        }
        else if(movementMode == 1)
        {
            movementDirection = new Vector3(-speedX, 0, speedZ);
        }
        else if(movementMode == 2)
        {
            movementDirection = new Vector3(speedX, 0, -speedZ);
        }
        else if(movementMode == 3)
        {
            movementDirection = new Vector3(-speedX, 0, -speedZ);
        }
        else if (movementMode == 4)
        {
            movementDirection = new Vector3(0, 0, speedZ);
        }
        else if (movementMode == 5)
        {
            movementDirection = new Vector3(0, 0, -speedZ);
        }
        else if (movementMode == 6)
        {
            movementDirection = new Vector3(speedX, 0, 0);
        }
        else
        {
            movementDirection = new Vector3(-speedX, 0, 0);
        }

        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, -velocity, 0, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * Time.deltaTime, Space.World);
        transform.forward = -movementDirection.normalized;

        if(remainingTime >= transitionTime && forceApplied)
        {
            rb.AddForce(0, 2*velocity, 0, ForceMode.VelocityChange);

            up = true;
            forceApplied = false;
        }
        else if(remainingTime <= 0 && !forceApplied)
        {
            rb.AddForce(0, -2*velocity, 0, ForceMode.VelocityChange);

            up = false;
            forceApplied = true;
        }

        if(up)
        {
            remainingTime = remainingTime - Time.deltaTime;
        }
        else
        {
            remainingTime = remainingTime + Time.deltaTime;
        }
    }
}
