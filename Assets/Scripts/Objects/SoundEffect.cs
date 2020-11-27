using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private AudioSource audioSource;
    public bool playEnabled;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playEnabled = false;
    }

    void Update()
    {
        if (playEnabled == true && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (playEnabled == true && audioSource.isPlaying)
        {
            playEnabled = false;
        }
    }
}
