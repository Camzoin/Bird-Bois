using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMover : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDirection, speed * Time.deltaTime);
    }
}
