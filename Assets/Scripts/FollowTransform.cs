using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Follow a given transform
public class FollowTransform : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followTarget.position + offset;
    }
}
