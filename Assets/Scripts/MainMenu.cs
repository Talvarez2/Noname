using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void changeAudioVolume(float volume)
    {
        audioSource.volume = volume;
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}
