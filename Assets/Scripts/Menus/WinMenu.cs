using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Level complete menu allowing the player to proceed to the next level or return to the main menu.
/// </summary>
public class WinMenu : MonoBehaviour
{
    public GameObject winMenuUI;
    public GameObject winMenuCamera;
    public GameObject winMenuEventSystem;
    public Button winMenuNextLevelButton;

    private GameObject _levelExtras;
    private const string LevelScenePrefix = "Level-";

    private void SetActiveMenuItems(bool value)
    {
        winMenuUI.SetActive(value);
        winMenuCamera.SetActive(value);
        winMenuEventSystem.SetActive(value);

        LevelSystem levelSystem = _levelExtras.GetComponent<LevelSystem>();
        winMenuNextLevelButton.interactable = levelSystem.CheckNextLevel();
    }

    /// <summary>
    /// Shows the win menu and pauses the game.
    /// </summary>
    public void Win()
    {
        _levelExtras = GameObject.FindWithTag("LevelExtras");
        SetActiveMenuItems(true);
        _levelExtras.GetComponent<LevelTimeScale>().StopLevel();
    }

    /// <summary>
    /// Loads the next level scene and unloads the current one.
    /// </summary>
    public void Next()
    {
        int nextLevel = _levelExtras.GetComponent<LevelSystem>().GetActualLevel() + 1;
        SceneManager.LoadScene(LevelScenePrefix + nextLevel, LoadSceneMode.Additive);
        _levelExtras.GetComponent<LevelTimeScale>().StartLevel();
        SetActiveMenuItems(false);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
