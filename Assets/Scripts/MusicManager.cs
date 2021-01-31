using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource track1, crossFadeTrack, track2;

    public static MusicManager instance;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);       
        if (instance == null)
        {
            instance = this;
        }
        crossFadeTrack.outputAudioMixerGroup.audioMixer.SetFloat("crossVol", 0);
    }

    public void SetMusic(AudioSource source, AudioClip audio)
    {
        source.clip = audio;
    }

    public void FadeMusic(AudioSource source, string exposedParam, float fadeDuration, float targetVol, bool stopMusic)
    {
        if (!stopMusic)
            source.Play();
        StartCoroutine(FadeMixerGroup.StartFade(source.outputAudioMixerGroup.audioMixer, exposedParam, fadeDuration, targetVol));
        if (stopMusic)
            StartCoroutine(StopAfterFade(source, fadeDuration));
    }

    IEnumerator StopAfterFade(AudioSource source, float stopDelay)
    {
        float elapsed = 0;

        while (elapsed <= stopDelay)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        source.Stop();
    }
}
