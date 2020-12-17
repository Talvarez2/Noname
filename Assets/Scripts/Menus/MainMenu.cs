using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    private AudioSource audioSource;
    private AudioSource gameaudioSource;
    private string standardLevelSceneName = "Level-";
    private string pauseSceneName = "Pause";
    private string lostSceneName = "YouLost";
    private string winSceneName = "YouWin";

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("Music Volume", 1);
        float gamevolume = PlayerPrefs.GetFloat("Game Volume", 1);

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;

        gameaudioSource = GetComponent<AudioSource>();
        gameaudioSource.volume = gamevolume;

        GameObject temp = this.transform.Find("OptionsMenu").gameObject;

        temp = temp.transform.Find("MusicVolumeSlider").gameObject;
        temp.GetComponent<Slider>().normalizedValue = volume;

        GameObject temp2 = this.transform.Find("OptionsMenu").gameObject;
        temp2 = temp.transform.Find("GameVolumeSlider").gameObject;
        temp2.GetComponent<Slider>().normalizedValue = gamevolume;
    }

    public void changeAudioVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Music Volume", volume);
    }

    public void changeGameVolume(float gamevolume)
    {
        gameaudioSource.volume = gamevolume;
        PlayerPrefs.SetFloat("Game Volume", gamevolume);
    }

    public void changeToLevel(int levelNumber)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);

        string levelSceneName = standardLevelSceneName.Insert(standardLevelSceneName.Length, levelNumber.ToString());

        SceneManager.LoadScene(levelSceneName);
        SceneManager.LoadScene(pauseSceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene(lostSceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene(winSceneName, LoadSceneMode.Additive);
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
