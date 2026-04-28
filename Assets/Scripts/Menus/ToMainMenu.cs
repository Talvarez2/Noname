using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Button handler that returns the player to the main menu scene.
/// </summary>
public class ToMainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName = "Menu";

    /// <summary>
    /// Unloads the current scene and loads the main menu.
    /// </summary>
    public void ChangeToMainMenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(sceneName);
    }
}
