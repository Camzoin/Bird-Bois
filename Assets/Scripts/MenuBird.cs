using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBird : MonoBehaviour
{
    public bool isGoing = false;
    float time = 2, curTime = 0;
    public Transform target;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGoing)
        {
            curTime = curTime + Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, target.position, curTime / time);
            gameObject.GetComponent<Animator>().SetBool("isFlying", true);
        }
    }
}
