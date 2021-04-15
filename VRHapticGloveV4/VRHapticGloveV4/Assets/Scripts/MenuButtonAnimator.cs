using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonAnimator : MonoBehaviour
{
    public Animator tutorial_anim; //song1 song2 son3 tutorial, stop
    public GameObject song1_1, song1_2, song2_1, song2_2, song3_1, song3_2, tutorial, stop;

    void Start()
    {
        tutorial_anim = tutorial.GetComponent<Animator>();
        
    }
    void Update()
    {
        if (LaunchPadFingerTrigger.tutorial||Input.GetKeyDown("7"))
        {
            tutorial_anim.Play("TutorialButtonPushed");
        }

    }
}
