using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] sound_sample;
    public AudioClip song;

    private void Start()
    {
        audioSource.PlayOneShot(song, 0.1F);
    }

    void Update()
    {
        
        if (LaunchPadFingerTrigger.l_bt1)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[0], 0.7F);
        }

        if (LaunchPadFingerTrigger.l_bt2)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[1], 0.7F);
        }

        if (LaunchPadFingerTrigger.l_bt3)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[2], 0.7F);
        }
        if (LaunchPadFingerTrigger.l_bt4)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[3], 0.7F);
        }

        if (LaunchPadFingerTrigger.l_bt5)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[4], 0.7F);
        }

        if (LaunchPadFingerTrigger.r_bt1)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[5], 0.7F);
        }
        if (LaunchPadFingerTrigger.r_bt2)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[6], 0.7F);
        }

        if (LaunchPadFingerTrigger.r_bt3)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[7], 0.7F);
        }

        if (LaunchPadFingerTrigger.r_bt4)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[8], 0.7F);
        }
        if (LaunchPadFingerTrigger.r_bt5)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound_sample[9], 0.7F);
        }       

    }
}
