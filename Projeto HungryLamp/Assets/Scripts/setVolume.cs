using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class setVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    
  
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("EffectVolume", 0.75f);
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("EffectVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("EffectVolume", sliderValue);
    }
    public void SetLevelMusic(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}
