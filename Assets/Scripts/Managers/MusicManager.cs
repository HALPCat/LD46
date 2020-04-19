using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region singleton pattern
    private static MusicManager _instance;
    public static MusicManager Instance { get { return _instance; } }
    
    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion 

    bool playing = false;
    AudioSource audioSource;
    public float volume;

    public MusicTrack[] musicTracks;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volume = 0.25f;
        audioSource.volume = volume;
        PlayMusic(musicTracks[0]);
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

    public void PlayMusic(MusicTrack musicTrack)
    {
        if(musicTrack == musicTracks[0])
        {
            audioSource.loop = true;
        }else{
            audioSource.loop = false;
        }
        float beatLength = 60f/musicTrack.bpm;
        Debug.Log(beatLength);
        //InvokeRepeating("Pulse", 0f, beatLength);
        audioSource.clip = musicTrack.song;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Pause();
    }

    public void AdjustVolume(float newVolume)
    {
        audioSource.volume = newVolume;
    }
}
