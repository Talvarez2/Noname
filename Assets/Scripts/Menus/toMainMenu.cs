using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName = "Menu";

    public void changeToMainMenuScene()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(sceneName);
    }
}
