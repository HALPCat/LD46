using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicTrack", menuName = "ScriptableObjects/MusicTrack")]
public class MusicTrack : ScriptableObject
{
    public int bpm;
    public AudioClip song;
}
