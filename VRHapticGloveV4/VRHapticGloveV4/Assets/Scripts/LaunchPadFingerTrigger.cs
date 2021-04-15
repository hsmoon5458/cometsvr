using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadFingerTrigger : MonoBehaviour
{
    public static bool button1, button2, button3, button4, button5;
    public static bool song1_lv1, song1_lv2, song2_lv1, song2_lv2, song3_lv1, song3_lv2, tutorial, stop_button;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "button1") { button1 = true; }
        if (other.gameObject.name == "button2") { button2 = true; }
        if (other.gameObject.name == "button3") { button3 = true; }
        if (other.gameObject.name == "button4") { button4 = true; }
        if (other.gameObject.name == "button5") { button5 = true; }

        if (other.gameObject.name == "Song1LV1_button") { song1_lv1 = true; }
        if (other.gameObject.name == "Song1LV2_button") { song1_lv2 = true; }
        if (other.gameObject.name == "Song2LV1_button") { song2_lv1 = true; }
        if (other.gameObject.name == "Song2LV2_button") { song2_lv2 = true; }
        if (other.gameObject.name == "Song3LV1_button") { song3_lv1 = true; }
        if (other.gameObject.name == "Song3LV2_button") { song3_lv2 = true; }
        if (other.gameObject.name == "Tutorial_button") { tutorial = true; }
        if (other.gameObject.name == "Stop_button") { stop_button = true; }



    }

    void OnTriggerExit(Collider other)
    {
        // song play stauts is for avoiding the play to be played multiple times
        if (other.gameObject.name == "Song1LV1_button") { song1_lv1 = false; }
        if (other.gameObject.name == "Song1LV2_button") { song1_lv2 = false; }
        if (other.gameObject.name == "Song2LV1_button") { song2_lv1 = false; }
        if (other.gameObject.name == "Song2LV2_button") { song2_lv2 = false; }
        if (other.gameObject.name == "Song3LV1_button") { song3_lv1 = false; }
        if (other.gameObject.name == "Song3LV2_button") { song3_lv2 = false; }
        if (other.gameObject.name == "Tutorial_button") { tutorial = false; }
        if (other.gameObject.name == "Stop_button") { stop_button = false; }
    }
}