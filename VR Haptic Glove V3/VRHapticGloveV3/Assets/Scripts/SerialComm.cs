using UnityEngine;
using System.IO.Ports;

public class SerialComm : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM8", 115200);

    void Start()
    {
        data_stream.Open(); //Initiate the Serial stream
    }

    // Update is called once per frame
    void Update()
    {
        if (FingerRead.L1J3)
        {
            data_stream.WriteLine("L1");
            Debug.Log("L1 Sent");
            FingerRead.L1J3 = false;
        }
        if (FingerRead.L2J3)
        {
            data_stream.WriteLine("L1");
            FingerRead.L2J3 = false;
        }
        if (FingerRead.L3J3)
        {
            data_stream.WriteLine("L1");
            FingerRead.L3J3 = false;
        }
        if (FingerRead.L4J3)
        {
            data_stream.WriteLine("L1");
            FingerRead.L4J3 = false;
        }
        if (FingerRead.L5J3)
        {
            data_stream.WriteLine("L1");
            FingerRead.L5J3 = false;
        }
        if (FingerRead.R1J3)
        {
            data_stream.WriteLine("L6");
            FingerRead.R1J3 = false;
        }
        if (FingerRead.R2J3)
        {
            data_stream.WriteLine("L7");
            FingerRead.R2J3 = false;
        }
        if (FingerRead.R3J3)
        {
            data_stream.WriteLine("L8");
            FingerRead.R3J3 = false;
        }
        if (FingerRead.R4J3)
        {
            data_stream.WriteLine("L9");
            FingerRead.R4J3 = false;
        }
        if (FingerRead.R5J3)
        {
            data_stream.WriteLine("L10");
            FingerRead.R5J3 = false;
        } 

    }
}
