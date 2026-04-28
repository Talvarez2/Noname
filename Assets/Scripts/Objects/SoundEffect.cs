using UnityEngine;

/// <summary>
/// Plays a one-shot sound effect. Set playEnabled to true to trigger playback.
/// </summary>
public class SoundEffect : MonoBehaviour
{
    public bool playEnabled;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        playEnabled = false;
    }

    private void Update()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("Game Volume", 1f);

        if (playEnabled && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        else if (playEnabled && _audioSource.isPlaying)
        {
            playEnabled = false;
        }
    }
}
