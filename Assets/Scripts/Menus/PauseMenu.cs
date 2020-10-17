using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuCamera;
    public GameObject pauseMenuEventSystem;
    private GameObject levelExtras;

    void Start()
    {
        levelExtras = GameObject.FindWithTag("LevelExtras");

        float volume = PlayerPrefs.GetFloat("Music Volume", 1);

        GameObject temp = this.transform.Find("OptionsMenu").gameObject;
        temp = temp.transform.Find("MusicVolumeSlider").gameObject;
        temp.GetComponent<Slider>().normalizedValue = volume;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
        }
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenuCamera.SetActive(true);
        pauseMenuEventSystem.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseMenuCamera.SetActive(false);
        pauseMenuEventSystem.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void changeAudioVolume(float volume)
    {
        AudioSource audioSource = levelExtras.GetComponent<AudioSource>();
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Music Volume", volume);
    }

}
