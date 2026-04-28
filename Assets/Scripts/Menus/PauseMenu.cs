using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Pause menu overlay with resume, retry, and volume options.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuCamera;
    public GameObject pauseMenuEventSystem;

    private GameObject _levelExtras;

    private void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("Music Volume", 1f);
        float gameVolume = PlayerPrefs.GetFloat("Game Volume", 1f);

        transform.Find("OptionsMenu/MusicVolumeSlider").GetComponent<Slider>().normalizedValue = musicVolume;
        transform.Find("OptionsMenu/GameVolumeSlider").GetComponent<Slider>().normalizedValue = gameVolume;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && gameIsPaused)
        {
            Resume();
        }
    }

    private void SetActiveMenuItems(bool value)
    {
        pauseMenuUI.SetActive(value);
        pauseMenuCamera.SetActive(value);
        pauseMenuEventSystem.SetActive(value);
    }

    /// <summary>
    /// Pauses the game and shows the pause menu.
    /// </summary>
    public void Pause()
    {
        SetActiveMenuItems(true);
        _levelExtras = GameObject.FindWithTag("LevelExtras");
        _levelExtras.GetComponent<LevelTimeScale>().StopLevel();
        gameIsPaused = true;
    }

    /// <summary>
    /// Resumes the game and hides the pause menu.
    /// </summary>
    public void Resume()
    {
        SetActiveMenuItems(false);
        _levelExtras.GetComponent<LevelTimeScale>().StartLevel();
        gameIsPaused = false;
    }

    /// <summary>
    /// Respawns players at the last checkpoint and resumes the game.
    /// </summary>
    public void Retry()
    {
        _levelExtras.GetComponent<SpawnSystem>().SendPlayersToLastSpawnsPositions();
        Resume();
    }

    /// <summary>
    /// Updates the music volume and saves the preference.
    /// </summary>
    public void ChangeAudioVolume(float volume)
    {
        _levelExtras.GetComponent<AudioSource>().volume = volume;
        PlayerPrefs.SetFloat("Music Volume", volume);
    }

    /// <summary>
    /// Updates the game sound effects volume preference.
    /// </summary>
    public void ChangeGameVolume(float volume)
    {
        PlayerPrefs.SetFloat("Game Volume", volume);
    }
}
