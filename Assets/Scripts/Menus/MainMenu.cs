using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Main menu controller handling level selection, volume settings, and quitting.
/// </summary>
public class MainMenu : MonoBehaviour
{
    private AudioSource _audioSource;
    private const string LevelScenePrefix = "Level-";
    private const string PauseSceneName = "Pause";
    private const string LostSceneName = "YouLost";
    private const string WinSceneName = "YouWin";

    private void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("Music Volume", 1f);
        float gameVolume = PlayerPrefs.GetFloat("Game Volume", 1f);

        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = musicVolume;

        transform.Find("OptionsMenu/MusicVolumeSlider").GetComponent<Slider>().normalizedValue = musicVolume;
        transform.Find("OptionsMenu/GameVolumeSlider").GetComponent<Slider>().normalizedValue = gameVolume;
    }

    /// <summary>
    /// Updates the music volume and saves the preference.
    /// </summary>
    public void ChangeAudioVolume(float volume)
    {
        _audioSource.volume = volume;
        PlayerPrefs.SetFloat("Music Volume", volume);
    }

    /// <summary>
    /// Updates the game sound effects volume preference.
    /// </summary>
    public void ChangeGameVolume(float volume)
    {
        PlayerPrefs.SetFloat("Game Volume", volume);
    }

    /// <summary>
    /// Loads the specified level along with overlay scenes (Pause, YouLost, YouWin).
    /// </summary>
    public void ChangeToLevel(int levelNumber)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(LevelScenePrefix + levelNumber);
        SceneManager.LoadScene(PauseSceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene(LostSceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene(WinSceneName, LoadSceneMode.Additive);
    }

    /// <summary>
    /// Exits the application.
    /// </summary>
    public void DoExitGame()
    {
        Application.Quit();
    }
}
