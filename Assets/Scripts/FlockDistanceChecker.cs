using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockDistanceChecker : MonoBehaviour
{
    public Transform bird, flock;

    public float maxDistance;

    public Animator animator;

    public AudioSource thunder;

    public AudioClip thunderSound;

    bool needsToPlay = false, hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(bird.position, flock.position) > maxDistance)
        {
            //fail
            animator.SetTrigger("Fail");
            needsToPlay = true;
        }

        if(needsToPlay == true && hasPlayed == false)
        {
            hasPlayed = true;
            thunder.PlayOneShot(thunderSound);
        }
    }
}
