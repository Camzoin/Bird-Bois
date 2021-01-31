using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VignetteController : MonoBehaviour
{
    public float timePerFrame = 1f;

    float curFrameTime = 0f;

    public SpriteRenderer vignette;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(curFrameTime < timePerFrame)
        {
            curFrameTime = curFrameTime + Time.deltaTime;
        }
        else
        {
            vignette.material.SetFloat("_Offset", Random.Range(0f, 100f));
            curFrameTime = 0f;
        }
    }
}