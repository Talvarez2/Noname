using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSystem : MonoBehaviour
{
    private bool[] playerOnExitDoor = { false, false };
    private GameObject winMenu;

    void Start()
    {
        LookForWinMenuGameObject();
    }

    private void LookForWinMenuGameObject()
    {
        Scene s = SceneManager.GetSceneByName("YouWin");
        GameObject[] gameObjects = s.GetRootGameObjects();
        foreach (var gameObject in gameObjects)
        {
            if (gameObject.name == "YouWinMenu")
            {
                winMenu = gameObject;
            }
        }
    }

    public void UpdatePlayerOnExitDoor(int playerNum)
    {
        playerOnExitDoor[playerNum - 1] = !playerOnExitDoor[playerNum - 1];

        bool levelFinished = true;
        foreach (var boolean in playerOnExitDoor)
        {
            if (boolean == false)
            {
                levelFinished = false;
            }
        }

        if (levelFinished == true)
        {
            winMenu.GetComponent<WinMenu>().Win();
        }
    }
}
