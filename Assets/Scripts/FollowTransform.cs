using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Follow a given transform
public class FollowTransform : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;
    public bool lockRotation;

    Quaternion origRotation;
    // Start is called before the first frame update
    void Start()
    {
        if (lockRotation)
        {
            origRotation = transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lockRotation)
        {
            transform.rotation = origRotation;
        }
        transform.position = followTarget.position + offset;
    }
}
