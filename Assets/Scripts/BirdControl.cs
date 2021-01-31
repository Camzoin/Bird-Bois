using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public bool inAir = true;

    #region Air Fields
    [SerializeField] float forwardSpeed = 10f;
    [SerializeField] float turnSpeed = 1f;

    [SerializeField] float minSpeed = 3f;
    [SerializeField] float maxSpeed = 15f;

    float accel = 3f;
    float decel = 3f;
    #endregion

    #region Ground Fields
    [SerializeField] float groundSpeed = 1f;
    [SerializeField] float groundRotateSpeed = 1f;
    [SerializeField] float jumpAmount = 5f;
    bool onGround = true;
    #endregion

    float seconds = 0f;

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

        seconds += Time.fixedDeltaTime;
        if (seconds >= 30)
        {
            animator.SetTrigger("Flap");
            seconds = 0f;
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
        float altitude = Input.GetAxisRaw("Vertical");
        rb.useGravity = false;
        
        if (Input.GetKey(KeyCode.Q) && forwardSpeed > minSpeed)
        {
            forwardSpeed -= decel * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.E) && forwardSpeed < maxSpeed)
        {
            forwardSpeed += accel * Time.fixedDeltaTime;
        }
        
        Vector3 direction = new Vector3(horizontal, altitude);
        direction.Normalize();

        transform.Translate(new Vector3(direction.x * turnSpeed, direction.y * turnSpeed, forwardSpeed) * Time.fixedDeltaTime);

        transform.Rotate(direction.y * turnSpeed, direction.x * turnSpeed, 0);
        Quaternion rot = transform.rotation;
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rot.eulerAngles = new Vector3(rot.eulerAngles.x, rot.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.fixedDeltaTime);
        }
        else
        {

        }
    }

    void GroundControl()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");
        rb.useGravity = true;
        Vector3 direction = new Vector3(horizontal, 0, forward);
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
