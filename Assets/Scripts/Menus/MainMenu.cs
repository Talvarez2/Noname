using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] private string sceneName = "Level-1";
    private string pauseSceneName = "Pause";
    private string lostSceneName = "YouLost";

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("Music Volume", 1);

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;

        GameObject temp = this.transform.Find("OptionsMenu").gameObject;
        temp = temp.transform.Find("MusicVolumeSlider").gameObject;
        temp.GetComponent<Slider>().normalizedValue = volume;
    }

    public void changeAudioVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Music Volume", volume);
    }

    public void changeToFirstLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(sceneName);
        SceneManager.LoadScene(pauseSceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene(lostSceneName, LoadSceneMode.Additive);
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}
