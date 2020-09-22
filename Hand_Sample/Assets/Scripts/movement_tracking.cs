using UnityEngine;
using System.Collections;
using System.IO.Ports;


public class movement_tracking : MonoBehaviour
{
    public Transform L2_J1, L2_J2, L2_J3, L3_J1, L3_J2, L3_J3, L4_J1, L4_J2, L4_J3, L5_J1, L5_J2, L5_J3;
    public float speed = 6f;
    SerialPort data_stream = new SerialPort("COM10", 19200); // Arduino is connected to COM10, with 19200 baud rate
    public string receivedstring;
    
   
    void Start()
    {
        data_stream.Open(); //Initiate the Serial stream
        InvokeRepeating("Serial_Data_Reading", 0f, 0.01f);
    }


    // Update is called once per frame
    void Update()
    {
        int recv_angl = Serial_Data_Reading();

        L2_J1.transform.eulerAngles = new Vector3(0, recv_angl, 0);
        L2_J2.transform.eulerAngles = new Vector3(0, L2_J1.transform.eulerAngles.y + recv_angl, 0);
        L2_J3.transform.eulerAngles = new Vector3(0, L2_J2.transform.eulerAngles.y + recv_angl, 0);

        L3_J1.transform.eulerAngles = new Vector3(0, recv_angl, 0);
        L3_J2.transform.eulerAngles = new Vector3(0, L3_J1.transform.eulerAngles.y + recv_angl, 0);
        L3_J3.transform.eulerAngles = new Vector3(0, L3_J2.transform.eulerAngles.y + recv_angl, 0);

        L4_J1.transform.eulerAngles = new Vector3(0, recv_angl, 0);
        L4_J2.transform.eulerAngles = new Vector3(0, L4_J1.transform.eulerAngles.y + recv_angl, 0);
        L4_J3.transform.eulerAngles = new Vector3(0, L4_J2.transform.eulerAngles.y + recv_angl, 0);
        L5_J1.transform.eulerAngles = new Vector3(0, recv_angl, 0);
        L5_J2.transform.eulerAngles = new Vector3(0, L5_J1.transform.eulerAngles.y + recv_angl, 0);
        L5_J3.transform.eulerAngles = new Vector3(0, L5_J2.transform.eulerAngles.y + recv_angl, 0);

    
    }

    int Serial_Data_Reading() // in order to sync the unity and serial port frequecny
    {
        //reading the Serial data below-----------------------------------

        receivedstring = data_stream.ReadLine();
        string[] datas = receivedstring.Split(','); //split the data between ','
        int recv_angl_data = Mathf.RoundToInt(float.Parse(datas[0]));

        return recv_angl_data;
    }
}