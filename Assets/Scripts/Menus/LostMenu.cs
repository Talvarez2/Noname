using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostMenu : MonoBehaviour
{
    public GameObject lostMenuUI;
    public GameObject lostMenuCamera;
    public GameObject lostMenuEventSystem;

    public void Lost()
    {
        lostMenuUI.SetActive(true);
        lostMenuCamera.SetActive(true);
        lostMenuEventSystem.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Reset()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in gameObjects)
        {
            go.GetComponent<Spawn>().handleReset();
        }
        Resume();
    }

    private void Resume()
    {
        lostMenuUI.SetActive(false);
        lostMenuCamera.SetActive(false);
        lostMenuEventSystem.SetActive(false);
        Time.timeScale = 1f;
    }
}
