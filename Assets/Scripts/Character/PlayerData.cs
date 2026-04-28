using UnityEngine;

/// <summary>
/// Per-player configuration data including player number, sprite renderer, and audio sources.
/// Adjusts sound volumes when the player changes the game volume setting.
/// </summary>
public class PlayerData : MonoBehaviour
{
    public int playerNum;
    public SpriteRenderer spriteRenderer;
    public bool isOnIceFloor = false;
    public AudioSource jumpSound;
    public AudioSource damageSound;

    private float _lastGameVolume;

    private void Start()
    {
        _lastGameVolume = PlayerPrefs.GetFloat("Game Volume", 1f);
    }

    private void Update()
    {
        float gameVolume = PlayerPrefs.GetFloat("Game Volume", 1f);
        if (!Mathf.Approximately(gameVolume, _lastGameVolume))
        {
            jumpSound.volume = gameVolume;
            damageSound.volume = gameVolume;
            _lastGameVolume = gameVolume;
        }
    }
}
