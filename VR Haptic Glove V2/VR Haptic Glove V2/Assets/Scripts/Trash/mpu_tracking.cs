using UnityEngine;
using System.IO.Ports;

public class mpu_tracking : MonoBehaviour
{
    public Transform cube;
    public Rigidbody cube_rb;
    SerialPort data_stream = new SerialPort("COM8", 19200); // Arduino Uno
    public string receivedstring;

    public bool stat;

    void Start()
    {
        data_stream.Open(); //Initiate the Serial stream
        InvokeRepeating("Serial_Data_Reading", 0f, 0.001f); // 0.001 make lag less
        
    }

    // Update is called once per frame
    void Update()
    {
        string[] recv_angl = Serial_Data_Reading();
        float Acc_X = float.Parse(recv_angl[0]);
        float Acc_Y = float.Parse(recv_angl[1]);
        float Acc_Z = float.Parse(recv_angl[2]);
        float GyroX = float.Parse(recv_angl[3]);
        float GyroY = float.Parse(recv_angl[4]);
        float GyroZ = float.Parse(recv_angl[5]);
        float GyroAngleX = float.Parse(recv_angl[6]);
        float GyroAngleY = float.Parse(recv_angl[7]);
        float GyroAngleZ = float.Parse(recv_angl[8]);
        float AngleX = float.Parse(recv_angl[9]);
        float AngleY = float.Parse(recv_angl[10]);
        float AngleZ = float.Parse(recv_angl[11]);

        //cube_rb.AddForce(Acc_X* Time.deltaTime,  Acc_Y* Time.deltaTime, Acc_Z* Time.deltaTime, ForceMode.VelocityChange);
        cube.eulerAngles= new Vector3(AngleX,AngleY,AngleZ);
    }

    string[] Serial_Data_Reading() // in order to sync the unity and serial port frequecny
    {
        //reading the Serial data below-----------------------------------

        receivedstring = data_stream.ReadLine();
        string[] datas = receivedstring.Split(','); //split the data between ','
        
        
        return datas;
    }
}

//Mathf.RoundToInt(float.Parse(datas[1]));