using UnityEngine;

public class Lefthand_move : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject Left;

    public float forwardFroce = 80;
    public float sidewaysForce = 80f;
    public float upwardForce = 80f;

    void FixedUpdate()
    {
        
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, forwardFroce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, -forwardFroce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("q"))
        {
            rb.transform.Rotate(Vector3.right * Time.deltaTime);
        }
        if (Input.GetKey("e"))
        {
            rb.transform.Rotate(Vector3.left * Time.deltaTime);
        }
        
    }
    

}
