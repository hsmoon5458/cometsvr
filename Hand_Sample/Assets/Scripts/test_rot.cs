using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class test_rot : MonoBehaviour
{
    public Transform c1, c2, c3, t1, t2 ,t3, ea;
    public float speed = 6f;

    SerialPort data_stream = new SerialPort("COM7", 9600); // Arduino is connected to COM7, with 9600 baud rate
    public string receivedstring;

    void Start()
    {
        data_stream.Open(); //Initiate the Serial stream
    }

      void Update()
    {
        receivedstring = data_stream.ReadLine();
        string[] datas = receivedstring.Split(','); //split the data between ','


        //convert the string to float, and round to the integer for the rotation angle
        int recv_angl = Mathf.RoundToInt(float.Parse(datas[0]));
        

        //1. how does eulerAngle work.
        ea.transform.eulerAngles = new Vector3(0, recv_angl, 0);

        //2. Rotate Around
        
        if (c1.transform.eulerAngles.y >= recv_angl) 
        {
            c1.transform.RotateAround(t1.transform.position, Vector3.down, speed);
        }
        if (c1.transform.eulerAngles.y < recv_angl)
        {
            c1.transform.RotateAround(t1.transform.position, Vector3.up, speed);
        }
        
        //3. eulerAngles with a joint
        t2.transform.eulerAngles = new Vector3(0, recv_angl, 0);
        
        //4. eulerAngles the parent to rorate the child
        t3.transform.eulerAngles = new Vector3(0, recv_angl, 0);
                
    }
}