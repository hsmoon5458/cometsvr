using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this scrpit should be attached to LevelMenu prefab.
public class GameLevels : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip song1, song2, song3, tutorial; //put songs

    public GameObject[] spawning; // position of the cube
    public GameObject cube1, cube2, cube3, cube4, cube5; // 5 prefabs
    public Quaternion cube_rotation = new Quaternion(0f, 0f, 0f, 1f);
    private Vector3 p1, p2, p3, p4, p5; // position of spawing for convinence
    private float beat_90 = 0.666667f; // time between each beat for 90bpm
    public float start_time_offset_song1 = 0.2f, start_time_offset_song2 = 0.11f, start_time_offset_song3 = 0.18f,
        start_time_offset_tutorial = 0.03f;
    private float offest_1 = 0.23f;
    public static bool song_play_status = false;

    void Start()
    {
        // set position as variables to easily hardcode the levels
        p1 = spawning[0].transform.position;
        p2 = spawning[1].transform.position;
        p3 = spawning[2].transform.position;
        p4 = spawning[3].transform.position;
        p5 = spawning[4].transform.position;

        audioSource = GetComponent<AudioSource>();


    }

    void Update()
    {

        // song play stauts is for avoiding the play to be played multiple times
        if (LaunchPadFingerTrigger.song1_lv1 || Input.GetKeyDown("1") && song_play_status == false)
        {
            Song1LV1();
            PlayAudio(song1);
            LaunchPadFingerTrigger.song1_lv1 = false;
            StartCoroutine(WaitStatus()); // wait 3 seconds to avoid button pushed multiple times
        }

        if (LaunchPadFingerTrigger.song1_lv2 && song_play_status == false)
        {
            Song1LV2();
            PlayAudio(song1);
            LaunchPadFingerTrigger.song1_lv2 = false;
            StartCoroutine(WaitStatus());
        }

        if (LaunchPadFingerTrigger.song2_lv1 && song_play_status == false)
        {
            Song2LV1();
            PlayAudio(song2);
            LaunchPadFingerTrigger.song2_lv1 = false;
            StartCoroutine(WaitStatus());
        }

        if (LaunchPadFingerTrigger.song2_lv2 && song_play_status == false)
        {
            Song2LV2();
            PlayAudio(song2);
            LaunchPadFingerTrigger.song2_lv2 = false;
            StartCoroutine(WaitStatus());
        }

        if (LaunchPadFingerTrigger.song3_lv1 && song_play_status == false)
        {
            Song3LV1();
            PlayAudio(song3);
            LaunchPadFingerTrigger.song3_lv1 = false;
            StartCoroutine(WaitStatus());
        }

        if (LaunchPadFingerTrigger.song3_lv2 && song_play_status == false)
        {
            Song3LV2();
            PlayAudio(song3);
            LaunchPadFingerTrigger.song3_lv2 = false;
            StartCoroutine(WaitStatus());
        }

        if (LaunchPadFingerTrigger.tutorial && song_play_status == false || Input.GetKeyDown("2"))
        {
            Tutorial();
            StartCoroutine(WaitASecSong(tutorial, 4.31f));
            LaunchPadFingerTrigger.tutorial = false;
            StartCoroutine(WaitStatus());
        }

        if (LaunchPadFingerTrigger.stop_button)
        {
            StopCoroutine("WaitASec"); // it is not working now.
            StopAudio();
            LaunchPadFingerTrigger.stop_button = false;
        }


    }

    private void Tutorial() // done but need to calibrate the timing
    {
        CubeFalling.cube_falling_speed = 2.5f;
        StartCoroutine(WaitASec(beat_90 * 1 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 2 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 3 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 4 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 5 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 6 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 7 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 8 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 9 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 10 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 11 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 12 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 13 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 14 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 15 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 16 + start_time_offset_tutorial, cube1, p1));

        StartCoroutine(WaitASec(beat_90 * 17 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 18 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 19 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 20 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 21 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 22 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 23 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 24 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 25 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 26 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 27 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 28 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 29 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 30 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 31 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 32 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 32 + start_time_offset_tutorial, cube5, p5));//

        StartCoroutine(WaitASec(beat_90 * 33 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 34 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 35 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 36 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 37 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 38 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 39 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 40 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 41 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 42 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 43 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 44 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 45 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 46 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 47 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 48 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 48 + start_time_offset_tutorial, cube5, p5));//

        StartCoroutine(WaitASec(beat_90 * 49 + start_time_offset_tutorial, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 49 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 50 + start_time_offset_tutorial, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 50 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 51 + start_time_offset_tutorial, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 51 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 52 + start_time_offset_tutorial, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 52 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 52.5f + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 53 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 53 + start_time_offset_tutorial, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 54 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 54 + start_time_offset_tutorial, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 55 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 55 + start_time_offset_tutorial, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 56 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 56 + start_time_offset_tutorial, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 56.5f + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 57 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 58 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 59 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 60 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 60.5f + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 61 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 61 + start_time_offset_tutorial, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 62 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 62 + start_time_offset_tutorial, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 63 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 63 + start_time_offset_tutorial, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 64 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 64 + start_time_offset_tutorial, cube5, p5));//
        StartCoroutine(WaitASec(beat_90 * 64.5f + start_time_offset_tutorial, cube4, p4));

        StartCoroutine(WaitASec(beat_90 * 65 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 65 + start_time_offset_tutorial, cube3, p3));//
        StartCoroutine(WaitASec(beat_90 * 66 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 66 + start_time_offset_tutorial, cube3, p3));//
        StartCoroutine(WaitASec(beat_90 * 67 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 67 + start_time_offset_tutorial, cube3, p3));//
        StartCoroutine(WaitASec(beat_90 * 68 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 68 + start_time_offset_tutorial, cube3, p3));//
        StartCoroutine(WaitASec(beat_90 * 68.5f + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 69 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 69 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 70 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 70 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 71 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 71 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 72 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 72 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 72.5f + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 73 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 74 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 75 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 76 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 76.5f + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 77 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 77 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 78 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 78 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 79 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 79 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 80 + start_time_offset_tutorial, cube1, p1));//
        StartCoroutine(WaitASec(beat_90 * 80 + start_time_offset_tutorial, cube4, p4));//
        StartCoroutine(WaitASec(beat_90 * 80.5f + start_time_offset_tutorial, cube3, p3));

        StartCoroutine(WaitASec(beat_90 * 83 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 84 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 85 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 86 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 87 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 88 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 89 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 90 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 91 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 92 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 93 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 94 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 95 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 96 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 97 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 98 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 99 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 100 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 101 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 102 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 103 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 104 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 105 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 106 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 107 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 108 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 109 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 110 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 111 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 112 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 113 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 114 + start_time_offset_tutorial, cube2, p2));

        StartCoroutine(WaitASec(beat_90 * 115 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 116 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 117 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 118 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 119 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 120 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 121 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 122 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 123 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 124 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 125 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 126 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 127 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 128 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 129 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 130 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 131 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 132 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 133 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 134 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 135 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 136 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 137 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 138 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 139 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 140 + start_time_offset_tutorial, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 141 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 142 + start_time_offset_tutorial, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 143 + start_time_offset_tutorial, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 144 + start_time_offset_tutorial, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 145 + start_time_offset_tutorial, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 146 + start_time_offset_tutorial, cube2, p2));

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

        StartCoroutine(WaitASec(beat_90 * 61 + offest_1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 63 + offest_1, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 65 + offest_1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 67 + offest_1, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 69 + offest_1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 71 + offest_1, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 73 + offest_1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 75 + offest_1, cube4, p4));

        StartCoroutine(WaitASec(beat_90 * 77 + offest_1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 79 + offest_1, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 81 + offest_1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 83 + offest_1, cube3, p3));
        StartCoroutine(WaitASec(beat_90 * 85 + offest_1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 87 + offest_1, cube4, p4));
        StartCoroutine(WaitASec(beat_90 * 89 + offest_1, cube2, p2));
        StartCoroutine(WaitASec(beat_90 * 91 + offest_1, cube4, p4));

        StartCoroutine(WaitASec(beat_90 * 93 + offest_1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 95 + offest_1, cube5, p5));
        StartCoroutine(WaitASec(beat_90 * 99 + offest_1, cube1, p1));
        StartCoroutine(WaitASec(beat_90 * 101 + offest_1, cube2, p2));//
        StartCoroutine(WaitASec(beat_90 * 101 + offest_1, cube4, p4));//
    }
    private void Song1LV2()
    {

    }

    private void Song2LV1()
    {
        
    }

    private void Song2LV2()
    {

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

        song_play_status = false;
    }

    private void Song3LV2()
    {

    }

    IEnumerator WaitASec(float waitTime, GameObject cube, Vector3 spawning_location)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(cube, spawning_location, cube_rotation);

    }

    IEnumerator WaitASecSong(AudioClip song, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PlayAudio(song);

    }

    IEnumerator WaitStatus()
    {
        yield return new WaitForSeconds(3f);
        song_play_status = true;
    }

    public void PlayAudio(AudioClip clipToPlay)
    {
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}

