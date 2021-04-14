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
            song_play_status = true;
        }

        if (LaunchPadFingerTrigger.song1_lv2 && song_play_status == false)
        {
            Song1LV2();
            PlayAudio(song1);
            LaunchPadFingerTrigger.song1_lv2 = false;
            song_play_status = true;
        }

        if (LaunchPadFingerTrigger.song2_lv1 && song_play_status == false)
        {
            Song2LV1();
            PlayAudio(song2);
            LaunchPadFingerTrigger.song2_lv1 = false;
            song_play_status = true;
        }

        if (LaunchPadFingerTrigger.song2_lv2 && song_play_status == false)
        {
            Song2LV2();
            PlayAudio(song2);
            LaunchPadFingerTrigger.song2_lv2 = false;
            song_play_status = true;
        }

        if (LaunchPadFingerTrigger.song3_lv1 && song_play_status == false)
        {
            Song3LV1();
            PlayAudio(song3);
            LaunchPadFingerTrigger.song3_lv1 = false;
            song_play_status = true;
        }

        if (LaunchPadFingerTrigger.song3_lv2 && song_play_status == false)
        {
            Song3LV2();
            PlayAudio(song3);
            LaunchPadFingerTrigger.song3_lv2 = false;
            song_play_status = true;
        }

        if (LaunchPadFingerTrigger.tutorial && song_play_status == false)
        {
            Tutorial();
            StartCoroutine(WaitASecSong(tutorial, 4.25f));
            LaunchPadFingerTrigger.tutorial = false;
            song_play_status = true;
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




        song_play_status = false;
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

