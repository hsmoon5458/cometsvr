using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script is located at the tip of index finger
public class ButtonTrigger : MonoBehaviour
{
    public static bool sw1_status, sw2_status, sw3_status, sw4_status, sw5_status, sw6_status, sw7_status, sw8_status, sw_r_status, sw_cal_status = false;
    public static bool sw_l_status = true; // if sw_r_status is ture, it has to be false, vice versa
    public static int last_sw_index = 9; // it is for feeding input for regression, make it out of index so make it inactive at the beginning
    void OnCollisionEnter(Collision other)
    {
        //if trigger on the index finger catch the name of each button,
        if (other.gameObject.name.Contains("switch1")) { sw1_status = true; last_sw_index = 0; }
        if (other.gameObject.name.Contains("switch2")) { sw2_status = true; last_sw_index = 1; }
        if (other.gameObject.name.Contains("switch3")) { sw3_status = true; last_sw_index = 2; }
        if (other.gameObject.name.Contains("switch4")) { sw4_status = true; last_sw_index = 3; }
        if (other.gameObject.name.Contains("switch5")) { sw5_status = true; last_sw_index = 4; }
        if (other.gameObject.name.Contains("switch6")) { sw6_status = true; last_sw_index = 5; }
        if (other.gameObject.name.Contains("switch7")) { sw7_status = true; last_sw_index = 6; }
        if (other.gameObject.name.Contains("switch8")) { sw8_status = true; last_sw_index = 7; }
        if (other.gameObject.name.Contains("switch_l")) { sw_l_status = true; sw_r_status = false; }
        if (other.gameObject.name.Contains("switch_r")) { sw_r_status = true; sw_l_status = false; }
        if (other.gameObject.name.Contains("calibration")) { sw_cal_status = true; }
    }
}
