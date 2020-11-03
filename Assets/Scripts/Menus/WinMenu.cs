using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenuUI;
    public GameObject winMenuCamera;
    public GameObject winMenuEventSystem;
    private GameObject levelExtras;
    private void SetActiveMenuItems(bool value)
    {
        winMenuUI.SetActive(value);
        winMenuCamera.SetActive(value);
        winMenuEventSystem.SetActive(value);
    }

    public void Win()
    {
        levelExtras = GameObject.FindWithTag("LevelExtras");
        SetActiveMenuItems(true);
        levelExtras.GetComponent<LevelTimeScale>().StopLevel();
    }

}
