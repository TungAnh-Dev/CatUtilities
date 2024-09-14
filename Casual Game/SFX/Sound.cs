
using UnityEngine;
[System.Serializable]
public class Sound 
{
    public string description;
    public SFXType type;
    public AudioClip clip;
    public float volume = 1;
    public int preferedAudioSource = 1;
}
