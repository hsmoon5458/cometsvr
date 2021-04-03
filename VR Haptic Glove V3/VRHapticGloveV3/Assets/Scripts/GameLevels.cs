using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevels : MonoBehaviour
{
    public GameObject[] spawning; // position of the cube
    public GameObject cube1, cube2, cube3, cube4, cube5; // 5 prefabs
    public Quaternion cube_rotation = new Quaternion(0f, 0f, 0f, 1f);
    private Vector3 p1, p2, p3, p4, p5;
    private float beat_90 = 0.666667f;
    public float start_time_offset_song1 = 0.2f, start_time_offset_song2 = 0.11f, start_time_offset_song3 = 0.18f;    

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
        if (Input.GetKeyDown("1"))
        {
            Song1LV1();
        }

        if (Input.GetKeyDown("2"))
        {
            Song2LV1();
        }

        if (Input.GetKeyDown("3"))
        {
            Song3LV1();
        }
       
    }

    private void Song1LV1() // done but need to calibrate the timing
    {
        CubeFalling.cube_falling_speed = 1.5f;
        StartCoroutine(WaitASec(beat_90 * 1 + start_time_offset_song1, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 3 + start_time_offset_song1, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 5 + start_time_offset_song1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 7 + start_time_offset_song1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 9 + start_time_offset_song1, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 11 + start_time_offset_song1, cube3, p3));

        StartCoroutine(WaitASec(beat_90 * 13 + start_time_offset_song1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 15 + start_time_offset_song1, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 17 + start_time_offset_song1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 19 + start_time_offset_song1, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 21 + start_time_offset_song1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 23 + start_time_offset_song1, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 25 + start_time_offset_song1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 27 + start_time_offset_song1, cube4, p4));

        StartCoroutine(WaitASec(beat_90 * 29 + start_time_offset_song1, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 29 + start_time_offset_song1, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 31 + start_time_offset_song1, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 31 + start_time_offset_song1, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 33 + start_time_offset_song1, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 35 + start_time_offset_song1, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 35 + start_time_offset_song1, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 37 + start_time_offset_song1, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 37 + start_time_offset_song1, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 39 + start_time_offset_song1, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 39 + start_time_offset_song1, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 41 + start_time_offset_song1, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 43 + start_time_offset_song1, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 43 + start_time_offset_song1, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 45 + start_time_offset_song1, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 45 + start_time_offset_song1, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 47 + start_time_offset_song1, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 47 + start_time_offset_song1, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 49 + start_time_offset_song1, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 51 + start_time_offset_song1, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 51 + start_time_offset_song1, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 53 + start_time_offset_song1, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 53 + start_time_offset_song1, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 55 + start_time_offset_song1, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 55 + start_time_offset_song1, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 56 + start_time_offset_song1, cube3, p3));

        StartCoroutine(WaitASec(beat_90 * 61 + start_time_offset_song1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 63 + start_time_offset_song1, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 65 + start_time_offset_song1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 67 + start_time_offset_song1, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 69 + start_time_offset_song1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 71 + start_time_offset_song1, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 73 + start_time_offset_song1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 75 + start_time_offset_song1, cube4, p4));

        StartCoroutine(WaitASec(beat_90 * 77 + start_time_offset_song1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 79 + start_time_offset_song1, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 81 + start_time_offset_song1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 83 + start_time_offset_song1, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 85 + start_time_offset_song1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 87 + start_time_offset_song1, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 89 + start_time_offset_song1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 91 + start_time_offset_song1, cube4, p4));

        StartCoroutine(WaitASec(beat_90 * 93 + start_time_offset_song1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 95 + start_time_offset_song1, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 99 + start_time_offset_song1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 101 + start_time_offset_song1, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 101 + start_time_offset_song1, cube4, p4));//





    }

    private void Song2LV1()
    {
        CubeFalling.cube_falling_speed = 1.5f;
        StartCoroutine(WaitASec(beat_90 * 1 + start_time_offset_song2, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 3 + start_time_offset_song2, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 5 + start_time_offset_song2, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 7 + start_time_offset_song2, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 9 + start_time_offset_song2, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 11 + start_time_offset_song2, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 13 + start_time_offset_song2, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 15 + start_time_offset_song2, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 17 + start_time_offset_song2, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 19 + start_time_offset_song2, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 21 + start_time_offset_song2, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 23 + start_time_offset_song2, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 25 + start_time_offset_song2, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 27 + start_time_offset_song2, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 29 + start_time_offset_song2, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 31 + start_time_offset_song2, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 33 + start_time_offset_song2, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 35 + start_time_offset_song2, cube1, p1));

    }

    private void Song3LV1()
    {
        CubeFalling.cube_falling_speed = 1.5f;
        StartCoroutine(WaitASec(beat_90 * 1 + start_time_offset_song3, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 3 + start_time_offset_song3, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 5 + start_time_offset_song3, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 7 + start_time_offset_song3, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 9 + start_time_offset_song3, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 11 + start_time_offset_song3, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 13 + start_time_offset_song3, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 15 + start_time_offset_song3, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 17 + start_time_offset_song3, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 19 + start_time_offset_song3, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 21 + start_time_offset_song3, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 23 + start_time_offset_song3, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 25 + start_time_offset_song3, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 27 + start_time_offset_song3, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 29 + start_time_offset_song3, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 31 + start_time_offset_song3, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 33 + start_time_offset_song3, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 35 + start_time_offset_song3, cube1, p1));

    }

    IEnumerator WaitASec(float waitTime, GameObject cube, Vector3 spawning_location)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(cube, spawning_location, cube_rotation);

    }
}

