using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHit : MonoBehaviour
{
    //public static bool cube1_triggered, cube2_triggered, cube3_triggered, cube4_triggered, cube5_triggered;
    public ParticleSystem effect1, effect2, effect3, effect4, effect5;
    public GameObject[] destination;
    public static int hit_count = 0;
    //public float[] deviation;
    //private int deviation_index = 0;

        void OnTriggerStay(Collider other)
        {
        if (other.gameObject.name.Contains("cube1") && LaunchPadFingerTrigger.button1)
        {
            effect1.Play();
            //record the deviation
            //deviation[deviation_index] = Vector3.Distance(other.gameObject.transform.position, destination[0].transform.position);
            //deviation_index++;
            
            Destroy(other.gameObject);
            hit_count++;
            LaunchPadFingerTrigger.button1 = false;
        }
        if (other.gameObject.name.Contains("cube2") && LaunchPadFingerTrigger.button2)
        {
            effect2.Play();
            //deviation[deviation_index] = Vector3.Distance(other.gameObject.transform.position, destination[1].transform.position);
            //deviation_index++;
            //Debug.Log(deviation[deviation_index]);
            Destroy(other.gameObject);
            hit_count++;
            LaunchPadFingerTrigger.button2 = false;
        }
        if (other.gameObject.name.Contains("cube3") && LaunchPadFingerTrigger.button3)
        {
            effect3.Play();
            //deviation[deviation_index] = Vector3.Distance(other.gameObject.transform.position, destination[2].transform.position);
            //deviation_index++;
            //Debug.Log(deviation[deviation_index]);
            Destroy(other.gameObject);
            hit_count++;
            LaunchPadFingerTrigger.button3 = false;
        }
        if (other.gameObject.name.Contains("cube4") && LaunchPadFingerTrigger.button4)
        {
            effect4.Play();
            //deviation[deviation_index] = Vector3.Distance(other.gameObject.transform.position, destination[3].transform.position);
            //deviation_index++;
            //Debug.Log(deviation[deviation_index]);
            Destroy(other.gameObject);
            hit_count++;
            LaunchPadFingerTrigger.button4 = false;
        }
        if (other.gameObject.name.Contains("cube5") && LaunchPadFingerTrigger.button5)
        {
            effect5.Play();
            //deviation[deviation_index] = Vector3.Distance(other.gameObject.transform.position, destination[4].transform.position);
            //deviation_index++;
            //Debug.Log(deviation[deviation_index]);
            Destroy(other.gameObject);
            hit_count++;
            LaunchPadFingerTrigger.button5 = false;
        }
    }
}


/*
  if (other.gameObject.name.Contains("cube1")) { cube1_triggered = true; }
        if (other.gameObject.name.Contains("cube2")) { cube2_triggered = true; }
        if (other.gameObject.name.Contains("cube3")) { cube3_triggered = true; }
        if (other.gameObject.name.Contains("cube4")) { cube4_triggered = true; }
        if (other.gameObject.name.Contains("cube5")) { cube5_triggered = true; }
 */
