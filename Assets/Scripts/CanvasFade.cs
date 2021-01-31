using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class CanvasFade : MonoBehaviour
{

    public float canvasFade = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.canvasFadeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalFloat("_CanvasFade", canvasFade);
    }
}
