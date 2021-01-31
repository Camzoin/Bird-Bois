using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : MonoBehaviour
{
    public Light directionalLight;
    public float stormDelay;

    ParticleSystem stormSystem;
    Material skyboxMaterial;
    float skyBoxBlend;
    float timer;
    bool stormPlayed;

    // Start is called before the first frame update
    void Start()
    {
        stormSystem = GetComponent<ParticleSystem>();
        skyboxMaterial = RenderSettings.skybox;
        skyBoxBlend = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < stormDelay)
        {
            timer += Time.deltaTime;
        }
        else if (!stormPlayed)
        {
            stormSystem.Play(true);
            StartCoroutine(LerpLightIntensity(directionalLight.intensity, 0.5f, 1));
            StartCoroutine(LerpBlend(0, 1, 1));
            stormPlayed = true;
        }
    }

    IEnumerator LerpBlend(float start, float end, float duration)
    {
        float elapsed = 0;

        while (elapsed <= duration)
        {
            elapsed += Time.deltaTime / duration;
            skyBoxBlend = Mathf.Lerp(start, end, elapsed);
            skyboxMaterial.SetFloat("_Blend", skyBoxBlend);
            yield return null;
        }
    }
    IEnumerator LerpLightIntensity(float start, float end, float duration)
    {
        float elapsed = 0;

        while (elapsed <= duration)
        {
            elapsed += Time.deltaTime / duration;
            directionalLight.intensity = Mathf.Lerp(start, end, elapsed);
            yield return null;
        }
    }
}
