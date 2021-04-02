using UnityEngine;

public class DetectObject : MonoBehaviour
{
    private bool collision_L1J3, collision_L2J3, collision_L3J3, collision_L4J3, collision_L5J3;
    private Vector3 offset_position, offset_rotation;
    
    public GameObject L2J3_object;
    void Update()
    {
        if(collision_L1J3 && collision_L2J3)
        {
            transform.position = L2J3_object.transform.position + offset_position;
            // may be need to use rotate around
            transform.eulerAngles = L2J3_object.transform.eulerAngles + offset_rotation;

        }
        
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name.Contains("L1J3"))
        {
            
        }

        if (collision.gameObject.name.Contains("L2J3"))
        {
            offset_position = transform.position - L2J3_object.transform.position;
            offset_rotation = transform.eulerAngles - L2J3_object.transform.eulerAngles;
        }

        if (collision.gameObject.name.Contains("L3J3"))
        {
            
        }

        if (collision.gameObject.name.Contains("L4J3"))
        {
            
        }

        if (collision.gameObject.name.Contains("L5J3"))
        {
            
        }

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("L1J3"))
        {
            collision_L1J3 = true;
        }
        if (collision.gameObject.name.Contains("L2J3"))
        {
            collision_L2J3 = true;
        }

        if (collision.gameObject.name.Contains("L3J3"))
        {
            collision_L3J3 = true;
        }

        if (collision.gameObject.name.Contains("L4J3"))
        {
            collision_L4J3 = true;
        }

        if (collision.gameObject.name.Contains("L5J3"))
        {
            collision_L5J3 = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("L1J3"))
        {
            collision_L1J3 = false;
        }

        if (collision.gameObject.name.Contains("L2J3"))
        {
            collision_L2J3 = false;
            offset_position = new Vector3(0f, 0f, 0f);
            offset_rotation = new Vector3(0f, 0f, 0f);
        }

        if (collision.gameObject.name.Contains("L3J3"))
        {
            collision_L3J3 = false;
        }

        if (collision.gameObject.name.Contains("L4J3"))
        {
            collision_L4J3 = false;
        }

        if (collision.gameObject.name.Contains("L5J3"))
        {
            collision_L5J3 = false;
        }
    }

}
