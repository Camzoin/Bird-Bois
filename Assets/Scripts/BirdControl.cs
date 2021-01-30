using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    public Rigidbody rb;
    public bool inAir = true;

    #region Air Fields
    public float forwardSpeed = 1f;
    public float turnSpeed = 0.2f;
    #endregion

    #region Ground Fields
    public float groundSpeed = 1f;
    public float groundRotateSpeed = 1f;
    public float jumpAmount = 5f;
    bool onGround = true;
    #endregion

    #region Monobehaviour Callbacks
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

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }

    void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }

    void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }
    #endregion

    #region Private Methods
    void AirControl()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        rb.useGravity = false;
        Vector3 direction = new Vector3(horizontal, vertical);
        direction.Normalize();

        transform.Translate(new Vector3(direction.x * turnSpeed, direction.y * turnSpeed, forwardSpeed) * Time.fixedDeltaTime);

        transform.Rotate(direction.y * turnSpeed, direction.x * turnSpeed, 0);
        Quaternion rot = transform.rotation;
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rot.eulerAngles = new Vector3(rot.eulerAngles.x, rot.eulerAngles.y, 0);
            Quaternion.Lerp(transform.rotation, rot, 0.1f);
            transform.rotation = rot;
        }
    }

    void GroundControl()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        rb.useGravity = true;
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize();

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpAmount, rb.velocity.z);
            onGround = false;
        }

        transform.Translate(direction * groundSpeed * Time.fixedDeltaTime);
        transform.Rotate(0, direction.x * groundRotateSpeed, 0);
    }
    #endregion
}
