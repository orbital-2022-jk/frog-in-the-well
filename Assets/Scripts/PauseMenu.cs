using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void Start()
    {
        // audioMixer = GetComponent<AudioMixer>();
        slider = GetComponent<Slider>();
        float curr_volume;
        audioMixer.GetFloat("volume", out curr_volume);
        Debug.Log(curr_volume);
        SetVolume(curr_volume);
        slider.value = curr_volume;
    }
}
