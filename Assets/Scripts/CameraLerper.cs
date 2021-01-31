using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerper : MonoBehaviour
{
    public Transform cameraTarget, bird;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraTarget.position, Time.deltaTime * 5);

        transform.LookAt(bird);
    }

}
