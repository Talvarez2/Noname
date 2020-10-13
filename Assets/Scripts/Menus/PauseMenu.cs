using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuCamera;
    public GameObject pauseMenuEventSystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
        }
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenuCamera.SetActive(true);
        pauseMenuEventSystem.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseMenuCamera.SetActive(false);
        pauseMenuEventSystem.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

}
