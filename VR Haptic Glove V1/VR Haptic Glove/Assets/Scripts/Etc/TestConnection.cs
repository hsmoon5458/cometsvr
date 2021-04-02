using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class TestConnection : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM7", 9600); // Arduino is connected to COM7, with 19200 baud rate
    public string receivedstring;
    public Rigidbody rb;
    public float sensitivity = 0.1f;

    public string[] datas;

    void Start()
    {
        data_stream.Open(); //Initiate the Serial stream
    }

    void Update()
    {
        receivedstring = data_stream.ReadLine();

        string[] datas = receivedstring.Split(','); //split the data between ','
        rb.AddForce(0, 0, float.Parse(datas[0])* sensitivity * Time.deltaTime, ForceMode.VelocityChange);
        rb.AddForce(float.Parse(datas[1]) * sensitivity * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        transform.Rotate(0, float.Parse(datas[2]), 0);
        
    }

    private void OnTriggerEnter()
    {
        Debug.Log("Entered");
        data_stream.WriteLine("L1");
    }

    private void OnTriggerExit()
    {
        Debug.Log("Exit");
        data_stream.WriteLine("L2");
    }
}