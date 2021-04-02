using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningLV1 : MonoBehaviour
{
    public GameObject[] spawning; // position of the cube
    public GameObject cube1, cube2, cube3, cube4, cube5; // p1, p3, p5 are B_Cube and p2 and p4 are T_cube
    public Quaternion cube_rotation = new Quaternion(0f, 0f, 0f, 1f);
    private Vector3 p1, p2, p3, p4, p5;

    void Start()
    {
        // set position as variables to easily hardcode the levels
        p1 = spawning[0].transform.position;
        p2 = spawning[1].transform.position;
        p3 = spawning[2].transform.position;
        p4 = spawning[3].transform.position;
        p5 = spawning[4].transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LV1();
        }

    }

    private void LV1()
    {
        StartCoroutine(WaitASec(0.2f, cube1, p1));
        StartCoroutine(WaitASec(0.6f, cube2, p2));
        StartCoroutine(WaitASec(1.0f, cube3, p3));
        StartCoroutine(WaitASec(1.4f, cube4, p4));
        StartCoroutine(WaitASec(1.8f, cube5, p5));
        StartCoroutine(WaitASec(2.2f, cube4, p4));
        StartCoroutine(WaitASec(2.6f, cube3, p3));
        StartCoroutine(WaitASec(3.0f, cube2, p2));
        StartCoroutine(WaitASec(3.4f, cube1, p1));

    }



    IEnumerator WaitASec(float waitTime, GameObject cube, Vector3 spawning_location)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(cube, spawning_location, cube_rotation);

    }
}
