using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] Slider backgroundSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider masterSlider;

    const string MIXER_MASTER = "masterVolume";
    const string MIXER_BGM = "backgroundVolume";
    const string MIXER_SFX = "sfxVolume";

    private void Awake()
    {
        backgroundSlider.onValueChanged.AddListener(SetBackgroundVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    public void SetMasterVolume (float volume)
    {
        audioMixer.SetFloat(MIXER_MASTER, Mathf.Log10(volume) * 20);
    }
    public void SetBackgroundVolume (float volume)
    {
        audioMixer.SetFloat(MIXER_BGM, Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume (float volume)
    {
        audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(volume) * 20);
        //this will help the player to adjust the sound of SFX; basically a reference
        FindObjectOfType<AudioManager>().Play("SwordSlash");
    }
}
