using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] private string sceneName = "Level-1";
    private string pauseSceneName = "Pause";

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void changeAudioVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void changeToFirstLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(sceneName);
        SceneManager.LoadScene(pauseSceneName, LoadSceneMode.Additive);
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}
