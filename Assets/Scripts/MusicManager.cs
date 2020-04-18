using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    bool playing = false;
    Canvas canvas;
    AudioSource audioSource;
    public Animator[] animators;

    public MusicTrack[] musicTracks;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        canvas = FindObjectOfType<Canvas>();
        animators = canvas.GetComponentsInChildren<Animator>();
        PlaySong(musicTracks[0]);
    }

    // Update is called once per frame
    void Update()
    {
        playing = audioSource.isPlaying;
        if(playing)
        {
            //Debug.Log(audioSource.time);
        }
    }

    void PlaySong(MusicTrack musicTrack)
    {
        float beatLength = 60f/musicTrack.bpm;
        Debug.Log(beatLength);
        InvokeRepeating("Pulse", 0f, beatLength);
        audioSource.clip = musicTrack.song;
        audioSource.Play();
    }

    void Pulse()
    {
        foreach(Animator a in animators)
        {
            a.SetTrigger("Pulse");
        }
        DanceButtons.Instance.NewDirection();
    }
}
