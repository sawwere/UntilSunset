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

    private const float _multiplier = 20f;

    private void Awake()
    {
        //slider.onValueChanged.AddListener(HandleSliderVallueChanged);
    }
    private void HandleSliderVallueChanged(float value)
    {
        //var volumeValue = Mathf.Log10(value) * _multiplier;
        //audioMixer.SetFloat(volumeParameter, volumeValue);
    }
  
}
