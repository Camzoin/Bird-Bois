using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float turnSpeed = 1f;
    public Rigidbody rb;

    bool inAir = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (inAir)
        {
            AirControl();
        }
        else
        {
            GroundControl();
        }
    }

    void AirControl()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);
        direction.Normalize();

        transform.Translate(new Vector3(direction.x * turnSpeed, direction.y * turnSpeed, forwardSpeed) * Time.deltaTime);

        transform.Rotate(direction.y * turnSpeed, direction.x * turnSpeed, 0);
    }

    void GroundControl()
    {

    }
}
