using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.instance.SetMusic(MusicManager.instance.crossFadeTrack, audioClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
