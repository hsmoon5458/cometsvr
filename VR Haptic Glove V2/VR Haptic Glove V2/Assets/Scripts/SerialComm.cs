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
        if (Input.GetKey("a"))
        {
            Debug.Log("Sent");
            data_stream.WriteLine("L1");
        }

        if (Input.GetKey("s"))
        {
            data_stream.WriteLine("L2");
        }

        if (Input.GetKey("d"))
        {
            data_stream.WriteLine("L3");
        }

        if (Input.GetKey("f"))
        {
            data_stream.WriteLine("L4");
        }
        if (Input.GetKey("g"))
        {
            data_stream.WriteLine("L5");
        }

        if (Input.GetKey("h"))
        {
            data_stream.WriteLine("L6");
        }

        if (Input.GetKey("j"))
        {
            data_stream.WriteLine("L7");
        }

        if (Input.GetKey("k"))
        {
            data_stream.WriteLine("L8");
        }
        if (Input.GetKey("l"))
        {
            data_stream.WriteLine("L9");
        }

        if (Input.GetKey(";"))
        {
            data_stream.WriteLine("L10");
        }
    }
}
