using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource AudioSourceBackgroundMusic;
    public AudioClip BackgroundsMusics;
    
    void Start()
    {
        AudioClip music = BackgroundsMusics;
        AudioSourceBackgroundMusic.clip = music;
        AudioSourceBackgroundMusic.loop = true;
        AudioSourceBackgroundMusic.Play();
    }

    void Update()
    {
        
    }
}
