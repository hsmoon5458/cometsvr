using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMoving : MonoBehaviour
{
    public GameObject[] switches;
    
    public Material not_pressed_material;
    public Material pressed_material;

    void Update()
    {
        if (ButtonTrigger.sw1_status)
        {
            switches[0].GetComponent<MeshRenderer>().material = pressed_material;
        }
        else
        {
            switches[0].GetComponent<MeshRenderer>().material = not_pressed_material;
        }

        if (ButtonTrigger.sw2_status)
        {
            switches[1].GetComponent<MeshRenderer>().material = pressed_material;
        }
        else
        {
            switches[1].GetComponent<MeshRenderer>().material = not_pressed_material;
        }

        if (ButtonTrigger.sw3_status)
        {
            switches[2].GetComponent<MeshRenderer>().material = pressed_material;
        }
        else
        {
            switches[2].GetComponent<MeshRenderer>().material = not_pressed_material;
        }

        if (ButtonTrigger.sw4_status)
        {
            switches[3].GetComponent<MeshRenderer>().material = pressed_material;
        }
        else
        {
            switches[3].GetComponent<MeshRenderer>().material = not_pressed_material;
        }

        if (ButtonTrigger.sw5_status)
        {
            switches[4].GetComponent<MeshRenderer>().material = pressed_material;
        }
        else
        {
            switches[4].GetComponent<MeshRenderer>().material = not_pressed_material;
        }

        if (ButtonTrigger.sw6_status)
        {
            switches[5].GetComponent<MeshRenderer>().material = pressed_material;
        }
        else
        {
            switches[5].GetComponent<MeshRenderer>().material = not_pressed_material;
        }

        if (ButtonTrigger.sw7_status)
        {
            switches[6].GetComponent<MeshRenderer>().material = pressed_material;
        }
        else
        {
            switches[6].GetComponent<MeshRenderer>().material = not_pressed_material;
        }

        if (ButtonTrigger.sw8_status)
        {
            switches[7].GetComponent<MeshRenderer>().material = pressed_material;
        }
        else
        {
            switches[7].GetComponent<MeshRenderer>().material = not_pressed_material;
        }

        if (ButtonTrigger.sw_l_status)
        {
            switches[8].GetComponent<MeshRenderer>().material = pressed_material;
        }
        else
        {
            switches[8].GetComponent<MeshRenderer>().material = not_pressed_material;
        }

        if (ButtonTrigger.sw_r_status)
        {
            switches[9].GetComponent<MeshRenderer>().material = pressed_material;
        }
        else
        {
            switches[9].GetComponent<MeshRenderer>().material = not_pressed_material;
        }


        if (ButtonTrigger.sw_cal_status)
        {
            switches[10].GetComponent<MeshRenderer>().material = pressed_material;

            ButtonTrigger.sw1_status = false;
            ButtonTrigger.sw2_status = false;
            ButtonTrigger.sw3_status = false;
            ButtonTrigger.sw4_status = false;
            ButtonTrigger.sw5_status = false;
            ButtonTrigger.sw6_status = false;
            ButtonTrigger.sw7_status = false;
            ButtonTrigger.sw8_status = false;
            StartCoroutine(CalSwitch (1f)); // make sw_cal_status false after 1 second.
        }
        else
        {
            switches[10].GetComponent<MeshRenderer>().material = not_pressed_material;
        }


    }

    //delay the calibration button to be false after pressed
    public IEnumerator CalSwitch(float t)
    {
        yield return new WaitForSeconds(t);
        ButtonTrigger.sw_cal_status = false;
    }
}
