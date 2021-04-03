using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerRead : MonoBehaviour
{
    public static bool L1J3, L2J3, L3J3, L4J3, L5J3, R1J3, R2J3, R3J3, R4J3, R5J3;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "L1J3") { L1J3 = true; }
        if (other.gameObject.name == "L2J3") { L2J3 = true; }
        if (other.gameObject.name == "L3J3") { L3J3 = true; }
        if (other.gameObject.name == "L4J3") { L4J3 = true; }
        if (other.gameObject.name == "L5J3") { L5J3 = true; }
        if (other.gameObject.name == "R1J3") { R1J3 = true; }
        if (other.gameObject.name == "R2J3") { R2J3 = true; }
        if (other.gameObject.name == "R3J3") { R3J3 = true; }
        if (other.gameObject.name == "R4J3") { R4J3 = true; }
        if (other.gameObject.name == "R5J3") { R5J3 = true; }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "L1J3") { L1J3 = false; }
        if (other.gameObject.name == "L2J3") { L2J3 = false; }
        if (other.gameObject.name == "L3J3") { L3J3 = false; }
        if (other.gameObject.name == "L4J3") { L4J3 = false; }
        if (other.gameObject.name == "L5J3") { L5J3 = false; }
        if (other.gameObject.name == "R1J3") { R1J3 = false; }
        if (other.gameObject.name == "R2J3") { R2J3 = false; }
        if (other.gameObject.name == "R3J3") { R3J3 = false; }
        if (other.gameObject.name == "R4J3") { R4J3 = false; }
        if (other.gameObject.name == "R5J3") { R5J3 = false; }

    }

}
