using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip song1, song2, song3;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown("1"))
        {
            PlayAudio(song1);
        }

        if (Input.GetKeyDown("2"))
        {
            PlayAudio(song2);
        }

        if (Input.GetKeyDown("3"))
        {
            PlayAudio(song3);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAudio();
        }
    }

    public void PlayAudio(AudioClip clipToPlay)
    {
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

}
