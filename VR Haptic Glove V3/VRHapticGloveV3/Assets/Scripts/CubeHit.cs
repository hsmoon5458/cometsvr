using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHit : MonoBehaviour
{
    //public static bool cube1_triggered, cube2_triggered, cube3_triggered, cube4_triggered, cube5_triggered;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("cube1") && LaunchPadFingerTrigger.button1) { Destroy(other.gameObject); }
        if (other.gameObject.name.Contains("cube2") && LaunchPadFingerTrigger.button2) { Destroy(other.gameObject); }
        if (other.gameObject.name.Contains("cube3") && LaunchPadFingerTrigger.button3) { Destroy(other.gameObject); }
        if (other.gameObject.name.Contains("cube4") && LaunchPadFingerTrigger.button4) { Destroy(other.gameObject); }
        if (other.gameObject.name.Contains("cube5") && LaunchPadFingerTrigger.button5) { Destroy(other.gameObject); }
    }
}


/*
  if (other.gameObject.name.Contains("cube1")) { cube1_triggered = true; }
        if (other.gameObject.name.Contains("cube2")) { cube2_triggered = true; }
        if (other.gameObject.name.Contains("cube3")) { cube3_triggered = true; }
        if (other.gameObject.name.Contains("cube4")) { cube4_triggered = true; }
        if (other.gameObject.name.Contains("cube5")) { cube5_triggered = true; }
 */
