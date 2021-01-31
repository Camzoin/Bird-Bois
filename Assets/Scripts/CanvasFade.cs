using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class CanvasFade : MonoBehaviour
{

    public float canvasFade = 0;

    void Start()
    {
        if (TryGetComponent(out Animator animator))
        {
            if (GameManager.instance != null)
                GameManager.instance.canvasFadeAnim = animator;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalFloat("_CanvasFade", canvasFade);
    }
}
