using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationControl : MonoBehaviour
{
    public Animator animate; // required for the animation of the object

    void Start()
    {
        animate = GetComponent<Animator>(); // grab the Animator from the Unity GameObject
    }

    // Update is called once per frame
    void Update()
    {
        if(LaunchPadFingerTrigger.button1){
            Debug.Log("pressed");
               animate.Play("Press Down");  // animation start condition, rest handled by the AnimationController
            }

        if(LaunchPadFingerTrigger.button1 == false){  // replace with deactivation condition

            animate.Play("Press Up");
        }
    }
}
