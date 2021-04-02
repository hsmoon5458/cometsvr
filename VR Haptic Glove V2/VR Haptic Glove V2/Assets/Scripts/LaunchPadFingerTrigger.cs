using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadFingerTrigger : MonoBehaviour
{
    public static bool button1, button2, button3, button4, button5, button6, button7, button8, button9;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "button1") { button1 = true; }
        if (other.gameObject.name == "button2") { button2 = true; }
        if (other.gameObject.name == "button3") { button3 = true; }
        if (other.gameObject.name == "button4") { button4 = true; }
        if (other.gameObject.name == "button5") { button5 = true; }

    }
}