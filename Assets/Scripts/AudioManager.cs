using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider MasterSlider;
    public Slider EffectsSlider;
    public Slider MusicSlider;
   

  
    public void Update()
    {
        Mixer.SetFloat("MasterVolume", MasterSlider.value);
        Mixer.SetFloat("EffectsVolume", EffectsSlider.value);
        Mixer.SetFloat("MusicVolume", MusicSlider.value);
    }

   
}
