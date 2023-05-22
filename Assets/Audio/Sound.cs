using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    public AudioMixerGroup output;

    [Range(0f, 1f)] public float volume;
    [Range(.1f, 1f)] public float pitch = 1f;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
