using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SliderMusic : MonoBehaviour
{
    public AudioMixer mixer;


    public void SetMusicLevel(float sliderValue)
    {

        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);

    }
}
