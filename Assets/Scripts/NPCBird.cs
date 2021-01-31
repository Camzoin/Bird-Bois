using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBird : MonoBehaviour
{
    public Animator animator;
    public float flapMin, flapMax;
    float flapInterval;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        flapInterval = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < flapInterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            animator.SetTrigger("Flap");
            flapInterval = Random.Range(1, 4);
            timer = 0;
        }
    }
}
