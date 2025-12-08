using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    public string currentState = "Play";
    public AudioMixer audioMixer;  // Используй сам AudioMixer, а не MixerGroup
    public Slider masterSlider;    // Подключаем слайдер для мастера
    public Slider musicSlider;     // Подключаем слайдер для музыки
    public Slider sfxSlider;       // Подключаем слайдер для эффектов

    // Start is called before the first frame update
    void Start()
    {
        // Устанавливаем начальные значения для ползунков
        float value;
        audioMixer.GetFloat("MasterVolume", out value);
        masterSlider.value = Mathf.InverseLerp(-80, 0, value);  // Преобразуем dB в нормализованное значение для слайдера

        audioMixer.GetFloat("MusicVolume", out value);
        musicSlider.value = Mathf.InverseLerp(-80, -30, value);

        audioMixer.GetFloat("SFXVolume", out value);
        sfxSlider.value = Mathf.InverseLerp(-80, 0, value);
    }

    // Update is called once per frame
    void Update()
    {
        AwakePause();
    }

    public void AwakePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (currentState)
            {
                case "Play":
                    Menu.SetActive(true);
                    Time.timeScale = 0;
                    pause();
                    break;
                case "Pause":
                    Menu.SetActive(false);
                    Time.timeScale = 1;
                    resume();
                    break;
            }
        }
    }

    public void resume()
    {
        currentState = "Play";
    }

    public void pause()
    {
        currentState = "Pause";
    }

    public void MasterVolume(float volume)
    {
        float dB = Mathf.Lerp(-80f, 0f, volume);
        audioMixer.SetFloat("MasterVolume", dB);  // Устанавливаем значение напрямую в dB
    }

    public void MusicVolume(float volume)
    {
        float dB = Mathf.Lerp(-80f, -30f, volume);
        audioMixer.SetFloat("MusicVolume", dB);
    }

    public void SFXVolume(float volume)
    {
        float dB = Mathf.Lerp(-80f, 0f, volume);
        audioMixer.SetFloat("SFXVolume", dB);
    }
}
