using UnityEngine;

/// <summary>
/// Checkpoint spawn point that changes color to indicate activation state.
/// Blue = unvisited, Green = visited by one player, Red = confirmed by both players.
/// </summary>
public class SpawnPoint : MonoBehaviour
{
    private Light _light;
    private SpriteRenderer _spriteRed;
    private SpriteRenderer _spriteGreen;
    private SpriteRenderer _spriteBlue;

    private void Start()
    {
        _light = GetComponentInChildren<Light>();
        _spriteRed = transform.Find("SpriteRed").GetComponent<SpriteRenderer>();
        _spriteGreen = transform.Find("SpriteGreen").GetComponent<SpriteRenderer>();
        _spriteBlue = transform.Find("SpriteBlue").GetComponent<SpriteRenderer>();

        _spriteRed.enabled = false;
        _spriteGreen.enabled = false;
        _spriteBlue.enabled = true;
    }

    /// <summary>
    /// Changes the checkpoint color and updates the visible sprite.
    /// </summary>
    public void ChangeColor(string color)
    {
        _spriteRed.enabled = color == "red";
        _spriteGreen.enabled = color == "green";
        _spriteBlue.enabled = color == "blue";

        if (color == "red") _light.color = Color.red;
        else if (color == "green") _light.color = Color.green;
        else if (color == "blue") _light.color = Color.blue;
    }

    /// <summary>
    /// Returns the current checkpoint color as a string.
    /// </summary>
    public string GetColor()
    {
        if (_light.color == Color.red) return "red";
        if (_light.color == Color.blue) return "blue";
        if (_light.color == Color.green) return "green";
        return null;
    }

    /// <summary>
    /// Triggers the checkpoint sound effect.
    /// </summary>
    public void ActivateAudio()
    {
        if (Time.time > 0.5f)
        {
            GetComponent<SoundEffect>().playEnabled = true;
        }
    }
}
