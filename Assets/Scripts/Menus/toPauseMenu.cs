using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toPauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    
    void Start()
    {
        LookForPauseMenuGameObject();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (pauseMenu.GetComponent<PauseMenu>().gameIsPaused == false)
            {
                pauseMenu.GetComponent<PauseMenu>().Pause();
            }
        }
    }

    private void LookForPauseMenuGameObject()
    {
        Scene s = SceneManager.GetSceneByName("Pause");
        GameObject[] gameObjects = s.GetRootGameObjects();
        foreach (var gameObject in gameObjects)
        {
            if (gameObject.name == "PauseMenu")
            {
                pauseMenu = gameObject;
            }
        }
    }
}
