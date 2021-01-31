using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMusic : StateMachineBehaviour
{
    [Range(1, 2)]
    public int musicManagerAudioSource;
    public string exposedParameter;
    public float fadeDuration;
    public float targetVolume;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AudioSource source;
        if (musicManagerAudioSource == 1)
        {
            source = MusicManager.instance.track1;
        }
        else if (musicManagerAudioSource == 2)
        {
            source = MusicManager.instance.track2;
        }
        else
        {
            source = MusicManager.instance.track1;
        }
        MusicManager.instance.FadeMusic(source, exposedParameter, fadeDuration, targetVolume, targetVolume == 0);
    }
}
