using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for Escape or P key presses to open the pause menu.
/// </summary>
public class ToPauseMenu : MonoBehaviour
{
    private GameObject _pauseMenu;

    private void Start()
    {
        FindPauseMenuGameObject();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PauseMenu pause = _pauseMenu.GetComponent<PauseMenu>();
            if (!pause.gameIsPaused)
            {
                pause.Pause();
            }
        }
    }

    private void FindPauseMenuGameObject()
    {
        Scene scene = SceneManager.GetSceneByName("Pause");
        foreach (GameObject rootObject in scene.GetRootGameObjects())
        {
            if (rootObject.name == "PauseMenu")
            {
                _pauseMenu = rootObject;
                return;
            }
        }
    }
}
