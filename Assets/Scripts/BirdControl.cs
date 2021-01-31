using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public AudioSource flapSource;
    public AudioSource walkSource;
    public bool inAir = true;

    #region Air Fields
    [SerializeField] float forwardSpeed = 10f;
    [SerializeField] float turnSpeed = 1f;

    [SerializeField] float minSpeed = 3f;
    [SerializeField] float maxSpeed = 15f;

    float horizontal;
    float vertical;

    float accel = 3f;
    float decel = 3f;
    #endregion

    #region Ground Fields
    [SerializeField] float groundSpeed = 1f;
    [SerializeField] float groundRotateSpeed = 1f;
    [SerializeField] float jumpAmount = 5f;
    bool onGround = true;
    #endregion

    #region Monobehaviour Callbacks
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (inAir)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            rb.useGravity = false;

            bool playFlap = false;

            if (Input.GetKey(KeyCode.Q) && forwardSpeed > minSpeed)
            {
                forwardSpeed -= decel * Time.fixedDeltaTime;
                animator.SetBool("Flap", true);
                playFlap = true;
            }
            if (Input.GetKey(KeyCode.E) && forwardSpeed < maxSpeed)
            {
                forwardSpeed += accel * Time.fixedDeltaTime;
                animator.SetBool("Flap", true);
                playFlap = true;
            }
            if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
            {
                animator.SetBool("Flap", false);
                playFlap = false;
            }

            // another way would be to create an aniamtion clip using the Flab aniamtion
            // then create a public method and put the code below in that method and have the clip call the method at a specific time in the clip
            if (!flapSource.isPlaying)
            {
                if (playFlap)
                {
                    flapSource.Play();
                }
                else
                {
                    flapSource.Stop();
                }
            }

            animator.SetBool("onGround", false);
        }
        else
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            rb.useGravity = true;

            bool playWalk = false;

            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpAmount, rb.velocity.z);
                onGround = false;
            }

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                playWalk = true;
            }
            else
            {
                playWalk = false;
            }

            // another way would be to create an aniamtion clip using the Flab aniamtion
            // then create a public method and put the code below in that method and have the clip call the method at a specific time in the clip
            if (!walkSource.isPlaying)
            {
                if (playWalk)
                {
                    walkSource.Play();
                }
                else
                {
                    walkSource.Stop();
                }
            }

            animator.SetBool("onGround", true);
        }
    }

    void FixedUpdate()
    {
        if (inAir)
        {
            AirControl(horizontal, vertical);
        }
        else
        {
            GroundControl(horizontal, vertical);
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
    void AirControl(float horValue, float altValue)
    {
        Vector3 direction = new Vector3(horValue, altValue);
        direction.Normalize();

        transform.Translate(new Vector3(direction.x * turnSpeed, direction.y * turnSpeed, forwardSpeed) * Time.fixedDeltaTime);

        transform.Rotate(direction.y * turnSpeed, direction.x * turnSpeed, 0);
        Quaternion rot = transform.rotation;
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rot.eulerAngles = new Vector3(rot.eulerAngles.x, rot.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.fixedDeltaTime);
        }
    }

    void GroundControl(float horValue, float forwardValue)
    {
        Vector3 direction = new Vector3(horValue, 0, forwardValue);
        direction.Normalize();

        transform.Translate(direction * groundSpeed * Time.fixedDeltaTime);
        transform.Rotate(0, direction.x * groundRotateSpeed, 0);
    }
    #endregion
}
