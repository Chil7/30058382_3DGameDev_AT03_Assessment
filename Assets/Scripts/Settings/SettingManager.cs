using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
    public void SetMusicVolume (float volume)
    {
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume (float volume)
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }
}
