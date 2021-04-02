using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public GameObject tv;

    private bool isPlaying;
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;

    void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        audioSource = gameObject.AddComponent<AudioSource>();
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        audioSource.Pause();
        // Video clip from Url
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = "https://youtu.be/iLBBRuVDOo4";

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);
        //Set video To Play then prepare Audio to prevent Buffering        
        videoPlayer.Prepare();

        //Play Video
        videoPlayer.Play();
        //Play Sound
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
