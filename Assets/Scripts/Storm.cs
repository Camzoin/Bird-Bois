using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Storm : MonoBehaviour
{
    public AudioClip[] stormAudio;
    public Light directionalLight;
    public float stormDelay;

    ParticleSystem stormSystem;
    Material skyboxMaterial;
    [SerializeField]
    AudioSource track1Source, track2Source;
    float skyBoxBlend;
    float timer;
    bool stormPlayed;

    // Start is called before the first frame update
    void Start()
    {
        stormSystem = GetComponent<ParticleSystem>();
        skyboxMaterial = RenderSettings.skybox;
        skyboxMaterial.SetFloat("_Blend", 0);
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
            StartCoroutine(PlayStormAudioSequence());
            stormPlayed = true;
        }
        
    }

    void PlayAudio(AudioSource source, AudioClip audioClip)
    {
        source.clip = audioClip;
        source.Play();
    }

    IEnumerator PlayStormAudioSequence()
    {
        track1Source.Play();
        yield return new WaitForSeconds(16f);
        StartCoroutine(FadeMixerGroup.StartFade(track1Source.outputAudioMixerGroup.audioMixer, "stormVol1", 5f, 0));
        Debug.Log("Music");
        track2Source.Play();
        StartCoroutine(FadeMixerGroup.StartFade(track1Source.outputAudioMixerGroup.audioMixer, "stormVol2", 2f, 1));
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
