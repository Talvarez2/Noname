using UnityEngine;

/// <summary>
/// Controls the game's time scale to pause and resume gameplay.
/// </summary>
public class LevelTimeScale : MonoBehaviour
{
    /// <summary>
    /// Pauses the game by setting Time.timeScale to zero.
    /// </summary>
    public void StopLevel()
    {
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Resumes the game by setting Time.timeScale to one.
    /// </summary>
    public void StartLevel()
    {
        Time.timeScale = 1f;
    }
}
