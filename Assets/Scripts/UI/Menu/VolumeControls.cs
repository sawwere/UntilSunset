using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControls : MonoBehaviour
{
   public AudioMixer audioMixer;
   public string volumeParameter = "MasterVolume";
   public Slider slider;
    public bool isCameraScript = false; 

    private const float _multiplier = 20f;

    private void Awake()
    {
        if (!isCameraScript)
        {
            slider.onValueChanged.AddListener(HandleSliderVallueChanged);
            if (PlayerPrefs.HasKey(volumeParameter))
            {
                slider.value = PlayerPrefs.GetFloat(volumeParameter);
            }
        }
        else
        {
            if (PlayerPrefs.HasKey(volumeParameter))
            {
                var volumeValue = Mathf.Log10(PlayerPrefs.GetFloat(volumeParameter)) * _multiplier;
                audioMixer.SetFloat(volumeParameter, volumeValue);
            }
        }
        
    }
    private void HandleSliderVallueChanged(float value)
    {
        var volumeValue = Mathf.Log10(value) * _multiplier;
        audioMixer.SetFloat(volumeParameter, volumeValue);
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }
  
}
