using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TestRight : MonoBehaviour
{
    SerialPort data_stream2 = new SerialPort("COM4", 115200);

    public string receivedstring2;

    void Start()
    {
        data_stream2.Open(); //Initiate the Serial stream
        InvokeRepeating("Serial_Data_Reading2", 0f, 0.01f); // 0.001 make lag less
    }

    // Update is called once per frame
    void Update()
    {
        string[] recv_angl2 = Serial_Data_Reading2();
        float t1 = float.Parse(recv_angl2[0]);
        float t2 = float.Parse(recv_angl2[1]);
        float t3 = float.Parse(recv_angl2[2]);
        float t4 = float.Parse(recv_angl2[3]);
        float t5 = float.Parse(recv_angl2[4]);
        float t6 = float.Parse(recv_angl2[5]);
        float t7 = float.Parse(recv_angl2[6]);
        float t8 = float.Parse(recv_angl2[7]);
        float t9 = float.Parse(recv_angl2[8]);

        transform.eulerAngles = new Vector3(t1, t2 , t3);

    }

    string[] Serial_Data_Reading2() // in order to sync the unity and serial port frequecny
    {
        //reading the Serial data below-----------------------------------
        receivedstring2 = data_stream2.ReadLine();
        string[] datas2 = receivedstring2.Split(','); //split the data between ','

        return datas2;
    }
}
