using UnityEngine;

using System.IO.Ports;


public class LeftHandTracking : MonoBehaviour
{
    public Transform left_hand, left_thumb, L1_J1, L1_J2, L1_J3, L2_J1, L2_J2, L2_J3, L3_J1, L3_J2, L3_J3, L4_J1, L4_J2, L4_J3, L5_J1, L5_J2, L5_J3;

    SerialPort data_stream_left = new SerialPort("COM12", 115200);
    public string receivedstring_right;

    // For the LS regression
    int[,] x_left = new int[4, 9]; //4 means for inputs for LS regression and 9 means 9 flex sensors 
    int[] y_left = new int[] { 5, 30, 60, 90 }; // y value is fixed.

    int[] x_sum_left = new int[9];
    int y_sum_left = 185; // sum of y[]

    int[] x_square_sum_left = new int[9];
    int[] x_y_sum_left = new int[9];

    public static float[] m_left = new float[9]; //slope
    public static float[] b_left = new float[9]; //y intercept

    // To display the angle for each finger
    public static float[] left_angl = new float[9];

    // For thumb movement check
    public float l_j1 = 0.5f, l_j2 = 0.6f, l_j3 = 0.7f;

    void Start()
    {
        data_stream_left.Open(); //Initiate the Serial stream
        InvokeRepeating("SerialDataReadingRight", 0f, 0.001f); // To remove the lagging

        m_left[0] = 0.5511f;
        m_left[1] = 0.5633f;
        m_left[2] = 0.5882f;
        m_left[3] = 0.5491f;
        m_left[4] = 0.6737f;
        m_left[5] = 0.9209f;
        m_left[6] = 0.8891f;
        m_left[7] = 0.8610f;
        m_left[8] = 0.8080f;

        b_left[0] = -123.15f;
        b_left[1] = -101.2f;
        b_left[2] = -128.48f;
        b_left[3] = -121.62f;
        b_left[4] = -144.57f;
        b_left[5] = -218.96f;
        b_left[6] = -183.58f;
        b_left[7] = -181.48f;
        b_left[8] = -184.85f;

    }


    void Update()
    {
        
        //Reading the data
        string[] recv_angl_left = SerialDataReadingRight();
                 
        float[] regression_angle_left = LS_RegressionLeft(recv_angl_left);

        int L1_J2_value = Mathf.RoundToInt(regression_angle_left[0]);
        int L2_J2_value = Mathf.RoundToInt(regression_angle_left[1]);
        int L3_J2_value = Mathf.RoundToInt(regression_angle_left[2]);
        int L4_J2_value = Mathf.RoundToInt(regression_angle_left[3]);
        int L5_J2_value = Mathf.RoundToInt(regression_angle_left[4]);

        int L2_J1_value = Mathf.RoundToInt(regression_angle_left[5]);
        int L3_J1_value = Mathf.RoundToInt(regression_angle_left[6]);
        int L4_J1_value = Mathf.RoundToInt(regression_angle_left[7]);
        int L5_J1_value = Mathf.RoundToInt(regression_angle_left[8]);


        // To display in Text ------------------erase this after completeion regression
        left_angl[0] = L1_J2_value;
        left_angl[1] = L2_J2_value;
        left_angl[2] = L3_J2_value;
        left_angl[3] = L4_J2_value;
        left_angl[4] = L5_J2_value;
        left_angl[5] = L2_J1_value;
        left_angl[6] = L3_J1_value;
        left_angl[7] = L4_J1_value;
        left_angl[8] = L5_J1_value;

        
        //Fingers angel
        L1_J1.eulerAngles = new Vector3(left_thumb.eulerAngles.x, left_thumb.eulerAngles.y - l_j1 * L1_J2_value, left_thumb.eulerAngles.z - L1_J2_value);
        L1_J2.eulerAngles = new Vector3(left_thumb.eulerAngles.x, L1_J1.eulerAngles.y - l_j2 * L1_J2_value, L1_J1.eulerAngles.z - L1_J2_value);
        L1_J3.eulerAngles = new Vector3(left_thumb.eulerAngles.x, L1_J2.eulerAngles.y - l_j3 * L1_J2_value, L1_J2.eulerAngles.z - L1_J2_value);

        L2_J1.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, left_hand.eulerAngles.z - L2_J1_value);
        L2_J2.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, L2_J1.eulerAngles.z - L2_J2_value);
        L2_J3.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, L2_J2.eulerAngles.z - L2_J2_value);

        L3_J1.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, left_hand.eulerAngles.z - L3_J1_value);
        L3_J2.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, L3_J1.eulerAngles.z - L3_J2_value);
        L3_J3.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, L3_J2.eulerAngles.z - L3_J2_value);

        L4_J1.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, left_hand.eulerAngles.z - L4_J1_value);
        L4_J2.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, L4_J1.eulerAngles.z - L4_J2_value);
        L4_J3.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, L4_J2.eulerAngles.z - L4_J2_value);

        L5_J1.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, left_hand.eulerAngles.z - L5_J1_value);
        L5_J2.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, L5_J1.eulerAngles.z - L5_J2_value);
        L5_J3.eulerAngles = new Vector3(left_hand.eulerAngles.x, left_hand.eulerAngles.y, L5_J2.eulerAngles.z - L5_J2_value);

    }

    string[] SerialDataReadingRight() // in order to sync the unity and serial port frequecny
    {
        //reading the Serial data below-----------------------------------
        receivedstring_right = data_stream_left.ReadLine();
        string[] datas = receivedstring_right.Split(','); //split the data between ','

        return datas;
    }

    // Regression output
    float[] LS_RegressionLeft(string[] input_angle)
    {
        float[] regression_angle = new float[9];

        for (int i = 0; i < 9; i++)
        {
            //apply the regerssion
            regression_angle[i] = m_left[i] * float.Parse(input_angle[i]) + b_left[i];

        }

        return regression_angle;
    }
}




// regression button setup
/*
 * //Regression Data Input, make the finger postion and press each button.
        //x[0] ~ x[4] are J2, x[5] ~ x[8] are J1
        //J2 5 degree
        if (ButtonTrigger.last_sw_index == 0 && ButtonTrigger.sw_l_status) {for (int i = 0; i < 5; i++){ x_left[0, i] = Mathf.RoundToInt(float.Parse(recv_angl_left[i]));}
            ButtonTrigger.last_sw_index = 10; // make it out of index so that it does not repeat multiple times
        }

        //J2 30 degree
        if (ButtonTrigger.last_sw_index == 1 && ButtonTrigger.sw_l_status) {for (int i = 0; i < 5; i++){ x_left[1, i] = Mathf.RoundToInt(float.Parse(recv_angl_left[i]));} 
            ButtonTrigger.last_sw_index = 10; }

        //J2 60 degree
        if (ButtonTrigger.last_sw_index == 2 && ButtonTrigger.sw_l_status) {for (int i = 0; i < 5; i++){ x_left[2, i] = Mathf.RoundToInt(float.Parse(recv_angl_left[i]));}
            ButtonTrigger.last_sw_index = 10; }

        //J2 90 degree
        if (ButtonTrigger.last_sw_index == 3 && ButtonTrigger.sw_l_status) {for (int i = 0; i < 5; i++){ x_left[3, i] = Mathf.RoundToInt(float.Parse(recv_angl_left[i]));}
            ButtonTrigger.last_sw_index = 10; }

        //J1 5 degree
        if (ButtonTrigger.last_sw_index == 4 && ButtonTrigger.sw_l_status) {for (int i = 5; i < 9; i++){ x_left[0, i] = Mathf.RoundToInt(float.Parse(recv_angl_left[i]));}
            ButtonTrigger.last_sw_index = 10; }

        //J1 30 degree
        if (ButtonTrigger.last_sw_index == 5 && ButtonTrigger.sw_l_status) {for (int i = 5; i < 9; i++){ x_left[1, i] = Mathf.RoundToInt(float.Parse(recv_angl_left[i]));}
            ButtonTrigger.last_sw_index = 10; }

        //J1 60 degree
        if (ButtonTrigger.last_sw_index == 6 && ButtonTrigger.sw_l_status) {for (int i = 5; i < 9; i++){ x_left[2, i] = Mathf.RoundToInt(float.Parse(recv_angl_left[i]));}
            ButtonTrigger.last_sw_index = 10; }

        //J1 90 degree
        if (ButtonTrigger.last_sw_index == 7 && ButtonTrigger.sw_l_status) {for (int i = 5; i < 9; i++){ x_left[3, i] = Mathf.RoundToInt(float.Parse(recv_angl_left[i]));}
            ButtonTrigger.last_sw_index = 10; }

        //Adjust new m and b 
        if (ButtonTrigger.sw_cal_status && ButtonTrigger.sw_l_status)
        {
            //LS Regression Algorithm
            for (int i = 0; i < 9; i++)
            {
                x_sum_left[i] = x_left[0, i] + x_left[1, i] + x_left[2, i] + x_left[3, i];
                x_square_sum_left[i] = (int)Mathf.Pow(x_left[0, i], 2) + (int)Mathf.Pow(x_left[1, i], 2) + (int)Mathf.Pow(x_left[2, i], 2) + (int)Mathf.Pow(x_left[3, i], 2);
                x_y_sum_left[i] = x_left[0, i] * y_left[0] + x_left[1, i] * y_left[1] + x_left[2, i] * y_left[2] + x_left[3, i] * y_left[3];

                // n = 4
                m_left[i] = (float)(4f * x_y_sum_left[i] - x_sum_left[i] * y_sum_left) / (float)(4 * x_square_sum_left[i] - (int)Mathf.Pow(x_sum_left[i], 2));
                b_left[i] = (1f / 4f) * (float)(y_sum_left - m_left[i] * x_sum_left[i]);
            }
            
        }
*/




