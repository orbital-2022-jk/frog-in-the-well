using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    void Start()
    {
        // audioMixer = GetComponent<AudioMixer>();
        slider = GetComponent<Slider>();
        float curr_volume;
        audioMixer.GetFloat("volume", out curr_volume);
        SetVolume(curr_volume);
        slider.value = curr_volume;
    }
}
