using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadFingerTrigger : MonoBehaviour
{
    public static bool l_bt1, l_bt2, l_bt3, l_bt4, l_bt5, r_bt1, r_bt2, r_bt3, r_bt4, r_bt5;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "l_button1") { l_bt1 = true; }
        if (other.gameObject.name == "l_button2") { l_bt2 = true; }
        if (other.gameObject.name == "l_button3") { l_bt3 = true; }
        if (other.gameObject.name == "l_button4") { l_bt4 = true; }
        if (other.gameObject.name == "l_button5") { l_bt5 = true; }
        if (other.gameObject.name == "r_button1") { r_bt1 = true; }
        if (other.gameObject.name == "r_button2") { r_bt2 = true; }
        if (other.gameObject.name == "r_button3") { r_bt3 = true; }
        if (other.gameObject.name == "r_button4") { r_bt4 = true; }
        if (other.gameObject.name == "r_button5") { r_bt5 = true; }

    }
}