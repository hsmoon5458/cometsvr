using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadAction : MonoBehaviour
{
    public ParticleSystem l_pt1, l_pt2, l_pt3, l_pt4, l_pt5, r_pt1, r_pt2, r_pt3, r_pt4, r_pt5;

    void Update()
    {
        if (LaunchPadFingerTrigger.l_bt1)
        {
            l_pt1.Play();
            LaunchPadFingerTrigger.l_bt1 = false;
        }

        if (LaunchPadFingerTrigger.l_bt2)
        {
            l_pt2.Play();
            LaunchPadFingerTrigger.l_bt2 = false;
        }

        if (LaunchPadFingerTrigger.l_bt3)
        {
            l_pt3.Play();
            LaunchPadFingerTrigger.l_bt3 = false;
        }

        if (LaunchPadFingerTrigger.l_bt4)
        {
            l_pt4.Play();
            LaunchPadFingerTrigger.l_bt4 = false;
        }

        if (LaunchPadFingerTrigger.l_bt5)
        {
            l_pt5.Play();
            LaunchPadFingerTrigger.l_bt5 = false;
        }

        if (LaunchPadFingerTrigger.r_bt1)
        {
            r_pt1.Play();
            LaunchPadFingerTrigger.r_bt1 = false;
        }

        if (LaunchPadFingerTrigger.r_bt2)
        {
            r_pt2.Play();
            LaunchPadFingerTrigger.r_bt2 = false;
        }

        if (LaunchPadFingerTrigger.r_bt3)
        {
            r_pt3.Play();
            LaunchPadFingerTrigger.r_bt3 = false;
        }

        if (LaunchPadFingerTrigger.r_bt4)
        {
            r_pt4.Play();
            LaunchPadFingerTrigger.r_bt4 = false;
        }

        if (LaunchPadFingerTrigger.r_bt5)
        {
            r_pt5.Play();
            LaunchPadFingerTrigger.r_bt5 = false;
        }

    }

}
