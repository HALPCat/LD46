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
    [SerializeField]
    AudioSource musicPlayerAS;
    [SerializeField]
    AudioSource soundPlayerAS;
    public float musicVolume;
    public float soundVolume;

    public AudioClip[] soundAudioClips;
    public MusicTrack[] musicTracks;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayerAS = transform.GetChild(0).GetComponent<AudioSource>();
        musicPlayerAS = GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        soundVolume = PlayerPrefs.GetFloat("soundVolume");
        musicPlayerAS.volume = musicVolume;
        soundPlayerAS.volume = soundVolume;
        PlayMusic(musicTracks[0]);
    }

    // Update is called once per frame
    void Update()
    {
        playing = musicPlayerAS.isPlaying;
        if(playing)
        {
            //Debug.Log(audioSource.time);
        }
    }

    public void PlayMusic(MusicTrack musicTrack)
    {
        if(musicTrack == musicTracks[0])
        {
            musicPlayerAS.loop = true;
        }else{
            musicPlayerAS.loop = false;
        }
        float beatLength = 60f/musicTrack.bpm;
        Debug.Log(beatLength);
        //InvokeRepeating("Pulse", 0f, beatLength);
        musicPlayerAS.clip = musicTrack.song;
        musicPlayerAS.Play();
    }

    public void StopMusic()
    {
        musicPlayerAS.Pause();
    }

    public void PlaySound(AudioClip clip)
    {
        soundPlayerAS.PlayOneShot(clip);
    }

    public void AdjustMusicVolume(float newVolume)
    {
        musicPlayerAS.volume = newVolume;
        PlayerPrefs.SetFloat("musicVolume", newVolume);
    }

    public void AdjustSoundVolume(float newVolume)
    {
        soundPlayerAS.volume = newVolume;
        PlayerPrefs.SetFloat("soundVolume", newVolume);
    }
}
