using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class LaunchPadEffects : MonoBehaviour
{
    public ParticleSystem particle_effect1, particle_effect2, particle_effect3, particle_effect4, particle_effect5;

    void Update()
    {
        if (LaunchPadFingerTrigger.button1)
        {
            particle_effect1.Play();
            LaunchPadFingerTrigger.button1 = false;
        }

        if (LaunchPadFingerTrigger.button2)
        {
            particle_effect2.Play();
            LaunchPadFingerTrigger.button2 = false;
        }

        if (LaunchPadFingerTrigger.button3)
        {
            particle_effect3.Play();
            LaunchPadFingerTrigger.button3 = false;
        }

        if (LaunchPadFingerTrigger.button4)
        {
            particle_effect4.Play();
            LaunchPadFingerTrigger.button4 = false;
        }

        if (LaunchPadFingerTrigger.button5)
        {
            particle_effect5.Play();
            LaunchPadFingerTrigger.button5 = false;
        }

    }

}
