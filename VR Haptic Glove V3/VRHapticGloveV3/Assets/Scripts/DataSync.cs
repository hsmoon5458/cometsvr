using Photon.Pun;
using System.IO.Ports;
using UnityEngine;

public class DataSync : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM8", 115200);

    private PhotonView PV;
    private bool L1, L2, L3, L4, L5, R1, R2, R3, R4, R5;// R1 = L6, R2 = L7 ,,, in Teensy to read
    void Start()
    {
        PV = GetComponent<PhotonView>();
        data_stream.Open(); //Initiate the Serial stream
    }

    void Update()
    {
        L1 = FingerRead.L1J3; // RPC cannot read static bool
        L2 = FingerRead.L2J3;
        L3 = FingerRead.L3J3;
        L4 = FingerRead.L4J3;
        L5 = FingerRead.L5J3;
        R1 = FingerRead.R1J3;
        R2 = FingerRead.R2J3;
        R3 = FingerRead.R3J3;
        R4 = FingerRead.R4J3;
        R5 = FingerRead.R5J3;


        if (PV.IsMine)
        {
            if (L1) {
                PV.RPC("RPC_DataSync", RpcTarget.AllBuffered, "L1");
                L1 = false;
            }
            if (L2)
            {
                PV.RPC("RPC_DataSync", RpcTarget.AllBuffered, "L2");
                L2 = false;
            }

            if (L3)
            {
                PV.RPC("RPC_DataSync", RpcTarget.AllBuffered, "L3");
                L3 = false;
            }
            if (L4)
            {
                PV.RPC("RPC_DataSync", RpcTarget.AllBuffered, "L4");
                L4 = false;
            }
            if (L5)
            {
                PV.RPC("RPC_DataSync", RpcTarget.AllBuffered, "L5");
                L5 = false;
            }
            if (R1)
            {
                PV.RPC("RPC_DataSync", RpcTarget.AllBuffered, "L6");
                R1 = false;
            }
            if (R2)
            {
                PV.RPC("RPC_DataSync", RpcTarget.AllBuffered, "L7");
                R2 = false;
            }
            if (R3)
            {
                PV.RPC("RPC_DataSync", RpcTarget.AllBuffered, "L8");
                R3 = false;
            }
            if (R4)
            {
                PV.RPC("RPC_DataSync", RpcTarget.AllBuffered, "L9");
                R4 = false;
            }
            if (R5)
            {
                PV.RPC("RPC_DataSync", RpcTarget.AllBuffered, "L10");
                R5 = false;
            }
        }
    }

    [PunRPC]
    void RPC_DataSync(string input)
    {
        data_stream.WriteLine(input);
        Debug.Log(input);
        Debug.Log("data Sent");
    }
}
