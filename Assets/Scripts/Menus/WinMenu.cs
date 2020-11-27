using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenuUI;
    public GameObject winMenuCamera;
    public GameObject winMenuEventSystem;
    public Button winMenuNextLevelButton;
    private GameObject levelExtras;
    private string standardLevelSceneName = "Level-";
    private void SetActiveMenuItems(bool value)
    {
        winMenuUI.SetActive(value);
        winMenuCamera.SetActive(value);
        winMenuEventSystem.SetActive(value);

        LevelSystem levelSystem = levelExtras.GetComponent<LevelSystem>();
        winMenuNextLevelButton.interactable = levelSystem.CheckNextLevel();
    }

    public void Win()
    {
        levelExtras = GameObject.FindWithTag("LevelExtras");
        SetActiveMenuItems(true);
        levelExtras.GetComponent<LevelTimeScale>().StopLevel();
    }

    public void Next()
    {
        LevelSystem levelSystem = levelExtras.GetComponent<LevelSystem>();
        int nextLevel = levelSystem.GetActualLevel() + 1;

        string levelSceneName = standardLevelSceneName.Insert(standardLevelSceneName.Length, nextLevel.ToString());
        Debug.Log(levelSceneName);
        SceneManager.LoadScene(levelSceneName, LoadSceneMode.Additive);
        levelExtras.GetComponent<LevelTimeScale>().StartLevel();
        SetActiveMenuItems(false);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);
    }

}
