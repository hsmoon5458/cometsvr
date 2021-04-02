using UnityEngine;

using System.IO.Ports;


public class RightHandTracking : MonoBehaviour
{
    public Transform right_hand, right_thumb, R1_J1, R1_J2, R1_J3, R2_J1, R2_J2, R2_J3, R3_J1, R3_J2, R3_J3, R4_J1, R4_J2, R4_J3, R5_J1, R5_J2, R5_J3;

    SerialPort data_stream_right = new SerialPort("COM14", 115200);
    public string receivedstring_right;

    // For the LS regression
    int[,] x_right = new int[4, 9]; //4 means for inputs for LS regression and 9 means 9 flex sensors 
    int[] y_right= new int[] { 5, 30, 60, 90 }; // y value is fixed.

    int[] x_sum_right = new int[9];
    int y_sum_right = 185; // sum of y[]

    int[] x_square_sum_right = new int[9];
    int[] x_y_sum_right = new int[9];

    public static float[] m_right = new float[9]; //slope
    public static float[] b_right = new float[9]; //y intercept

    // To display the angle for each finger
    public static float[] right_angl = new float[9];

    // For thumb movement check
    public float r_j1 = 0.2f, r_j2 = 0.1f, r_j3 = 0.2f;

    void Start()
    {
        data_stream_right.Open(); //Initiate the Serial stream
        InvokeRepeating("SerialDataReadingRight", 0f, 0.001f); // To remove the lagging

        m_right[0] = 0.5511f;
        m_right[1] = 0.5633f;
        m_right[2] = 0.5882f;
        m_right[3] = 0.5491f;
        m_right[4] = 0.6737f;
        m_right[5] = 0.9209f;
        m_right[6] = 0.8891f;
        m_right[7] = 0.8610f;
        m_right[8] = 0.8080f;

        b_right[0] = -123.15f;
        b_right[1] = -101.2f;
        b_right[2] = -128.48f;
        b_right[3] = -121.62f;
        b_right[4] = -144.57f;
        b_right[5] = -218.96f;
        b_right[6] = -183.58f;
        b_right[7] = -181.48f;
        b_right[8] = -184.85f;
    }


    void Update()
    {

        //Reading the data
        string[] recv_angl_right = SerialDataReadingRight();

        float[] regression_angle_right = LS_RegressionRight(recv_angl_right);

        int R1_J2_value = Mathf.RoundToInt(regression_angle_right[0]);
        int R2_J2_value = Mathf.RoundToInt(regression_angle_right[1]);
        int R3_J2_value = Mathf.RoundToInt(regression_angle_right[2]);
        int R4_J2_value = Mathf.RoundToInt(regression_angle_right[3]);
        int R5_J2_value = Mathf.RoundToInt(regression_angle_right[4]);

        int R2_J1_value = Mathf.RoundToInt(regression_angle_right[5]);
        int R3_J1_value = Mathf.RoundToInt(regression_angle_right[6]);
        int R4_J1_value = Mathf.RoundToInt(regression_angle_right[7]);
        int R5_J1_value = Mathf.RoundToInt(regression_angle_right[8]);

        // To display in Text ------------------erase this after completeion regression
        right_angl[0] = R1_J2_value;
        right_angl[1] = R2_J2_value;
        right_angl[2] = R3_J2_value;
        right_angl[3] = R4_J2_value;
        right_angl[4] = R5_J2_value;
        right_angl[5] = R2_J1_value;
        right_angl[6] = R3_J1_value;
        right_angl[7] = R4_J1_value;
        right_angl[8] = R5_J1_value;

        //Fingers angel
        R1_J1.eulerAngles = new Vector3(right_thumb.eulerAngles.x, right_thumb.eulerAngles.y - r_j1 * R1_J2_value, right_thumb.eulerAngles.z - R1_J2_value);
        R1_J2.eulerAngles = new Vector3(right_thumb.eulerAngles.x, R1_J1.eulerAngles.y - r_j2 * R1_J2_value, R1_J1.eulerAngles.z - R1_J2_value);
        R1_J3.eulerAngles = new Vector3(right_thumb.eulerAngles.x, R1_J2.eulerAngles.y - r_j3 * R1_J2_value, R1_J2.eulerAngles.z - R1_J2_value);

        R2_J1.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, right_hand.eulerAngles.z - R2_J1_value);
        R2_J2.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, R2_J1.eulerAngles.z - R2_J2_value);
        R2_J3.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, R2_J2.eulerAngles.z - R2_J2_value);

        R3_J1.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, right_hand.eulerAngles.z - R3_J1_value);
        R3_J2.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, R3_J1.eulerAngles.z - R3_J2_value);
        R3_J3.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, R3_J2.eulerAngles.z - R3_J2_value);

        R4_J1.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, right_hand.eulerAngles.z - R4_J1_value);
        R4_J2.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, R4_J1.eulerAngles.z - R4_J2_value);
        R4_J3.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, R4_J2.eulerAngles.z - R4_J2_value);

        R5_J1.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, right_hand.eulerAngles.z - R5_J1_value);
        R5_J2.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, R5_J1.eulerAngles.z - R5_J2_value);
        R5_J3.eulerAngles = new Vector3(right_hand.eulerAngles.x, right_hand.eulerAngles.y, R5_J2.eulerAngles.z - R5_J2_value);

    }

    string[] SerialDataReadingRight() // in order to sync the unity and serial port frequecny
    {
        //reading the Serial data below-----------------------------------
        receivedstring_right = data_stream_right.ReadLine();
        string[] datas = receivedstring_right.Split(','); //split the data between ','

        return datas;
    }

    // Regression output
    float[] LS_RegressionRight(string[] input_angle)
    {
        float[] regression_angle = new float[9];

        for (int i = 0; i < 9; i++)
        {
            regression_angle[i] = m_right[i] * float.Parse(input_angle[i]) + b_right[i];

            if (regression_angle[i] < 0)
            {
                regression_angle[i] = 0;
            }
        }

        return regression_angle;
    }
}




/*
 * 
        //Regression Data Input, make the finger postion and press each button.
        //x[0] ~ x[4] are J2, x[5] ~ x[8] are J1
        //J2 5 degree
        if (ButtonTrigger.last_sw_index == 0 && ButtonTrigger.sw_r_status) { for (int i = 0; i < 5; i++) { x_right[0, i] = Mathf.RoundToInt(float.Parse(recv_angl_right[i])); }
        ButtonTrigger.last_sw_index = 10; // make it out of index so that it does not repeat multiple times
        }

        //J2 30 degree
        if (ButtonTrigger.last_sw_index == 1 && ButtonTrigger.sw_r_status) { for (int i = 0; i < 5; i++) { x_right[1, i] = Mathf.RoundToInt(float.Parse(recv_angl_right[i])); }
            ButtonTrigger.last_sw_index = 10;
        }

        //J2 60 degree
        if (ButtonTrigger.last_sw_index == 2 && ButtonTrigger.sw_r_status) { for (int i = 0; i < 5; i++) { x_right[2, i] = Mathf.RoundToInt(float.Parse(recv_angl_right[i])); }
            ButtonTrigger.last_sw_index = 10;
        }

        //J2 90 degree
        if (ButtonTrigger.last_sw_index == 3 && ButtonTrigger.sw_r_status) { for (int i = 0; i < 5; i++) { x_right[3, i] = Mathf.RoundToInt(float.Parse(recv_angl_right[i])); }
            ButtonTrigger.last_sw_index = 10;
        }

        //J1 5 degree
        if (ButtonTrigger.last_sw_index == 4 && ButtonTrigger.sw_r_status) { for (int i = 5; i < 9; i++) { x_right[0, i] = Mathf.RoundToInt(float.Parse(recv_angl_right[i])); }
            ButtonTrigger.last_sw_index = 10;
        }

        //J1 30 degree
        if (ButtonTrigger.last_sw_index == 5 && ButtonTrigger.sw_r_status) { for (int i = 5; i < 9; i++) { x_right[1, i] = Mathf.RoundToInt(float.Parse(recv_angl_right[i])); }
            ButtonTrigger.last_sw_index = 10;
        }

        //J1 60 degree
        if (ButtonTrigger.last_sw_index == 6 && ButtonTrigger.sw_r_status) { for (int i = 5; i < 9; i++) { x_right[2, i] = Mathf.RoundToInt(float.Parse(recv_angl_right[i])); }
            ButtonTrigger.last_sw_index = 10;
        }

        //J1 90 degree
        if (ButtonTrigger.last_sw_index == 7 && ButtonTrigger.sw_r_status) { for (int i = 5; i < 9; i++) { x_right[3, i] = Mathf.RoundToInt(float.Parse(recv_angl_right[i])); }
            ButtonTrigger.last_sw_index = 10;
        }

        //Adjust new m and b 
        if (ButtonTrigger.sw_cal_status && ButtonTrigger.sw_r_status)
        {
            //LS Regression Algorithm
            for (int i = 0; i < 9; i++)
            {
                x_sum_right[i] = x_right[0, i] + x_right[1, i] + x_right[2, i] + x_right[3, i];
                x_square_sum_right[i] = (int)Mathf.Pow(x_right[0, i], 2) + (int)Mathf.Pow(x_right[1, i], 2) + (int)Mathf.Pow(x_right[2, i], 2) + (int)Mathf.Pow(x_right[3, i], 2);
                x_y_sum_right[i] = x_right[0, i] * y_right[0] + x_right[1, i] * y_right[1] + x_right[2, i] * y_right[2] + x_right[3, i] * y_right[3];

                // n = 4
                m_right[i] = (float)(4f * x_y_sum_right[i] - x_sum_right[i] * y_sum_right) / (float)(4 * x_square_sum_right[i] - (int)Mathf.Pow(x_sum_right[i], 2));
                b_right[i] = (1f / 4f) * (float)(y_sum_right - m_right[i] * x_sum_right[i]);
            }

        }

*/