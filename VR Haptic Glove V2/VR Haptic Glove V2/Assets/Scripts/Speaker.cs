using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] sound_sample;
    public AudioClip song;

    void Update()
    {
        
        if (LaunchPadFingerTrigger.button1)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[0], 0.7F);
        }

        if (LaunchPadFingerTrigger.button2)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[1], 0.7F);
        }

        if (LaunchPadFingerTrigger.button3)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[2], 0.7F);
        }
        if (LaunchPadFingerTrigger.button4)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[3], 0.7F);
        }

        if (LaunchPadFingerTrigger.button5)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[4], 0.7F);
        }


    }
}
