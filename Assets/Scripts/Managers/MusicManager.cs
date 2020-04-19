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

    public MusicTrack[] musicTracks;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        //InvokeRepeating("Pulse", 0f, beatLength);
        audioSource.clip = musicTrack.song;
        audioSource.Play();
    }
}
