﻿using System.Collections;
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
    private GameObject checkpoints;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("Music Volume", 1);
        GameObject temp = this.transform.Find("OptionsMenu").gameObject;
        temp = temp.transform.Find("MusicVolumeSlider").gameObject;
        temp.GetComponent<Slider>().normalizedValue = volume;

        float volumeGame = PlayerPrefs.GetFloat("Game Volume", 1);
        GameObject tempGame = this.transform.Find("OptionsMenu").gameObject;
        tempGame = tempGame.transform.Find("GameVolumeSlider").gameObject;
        tempGame.GetComponent<Slider>().normalizedValue = volumeGame;
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

    private void SetActiveMenuItems(bool value)
    {
        pauseMenuUI.SetActive(value);
        pauseMenuCamera.SetActive(value);
        pauseMenuEventSystem.SetActive(value);
    }
    
    public void Pause()
    {
        SetActiveMenuItems(true);
        levelExtras = GameObject.FindWithTag("LevelExtras");
        levelExtras.GetComponent<LevelTimeScale>().StopLevel();
        gameIsPaused = true;
    }

    public void Resume()
    {
        SetActiveMenuItems(false);
        levelExtras.GetComponent<LevelTimeScale>().StartLevel();
        gameIsPaused = false;
    }

    public void Retry()
    {
        levelExtras.GetComponent<SpawnSystem>().SendPlayersToLastSpawnsPositions();
        Resume();
    }

    public void changeAudioVolume(float volume)
    {
        AudioSource audioSource = levelExtras.GetComponent<AudioSource>();
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Music Volume", volume);
    }

    public void changeGameVolume(float volume)
    {
        //AudioSource audioSource = levelExtras.GetComponent<AudioSource>();
        //audioSource.volume = volume;
        PlayerPrefs.SetFloat("Game Volume", volume);
    }



}
