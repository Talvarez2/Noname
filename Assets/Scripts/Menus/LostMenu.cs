using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostMenu : MonoBehaviour
{
    public GameObject lostMenuUI;
    public GameObject lostMenuCamera;
    public GameObject lostMenuEventSystem;
    private GameObject levelExtras;

    private void Start()
    {
        levelExtras = GameObject.FindWithTag("LevelExtras");
    }

    private void SetActiveMenuItems(bool value)
    {
        lostMenuUI.SetActive(value);
        lostMenuCamera.SetActive(value);
        lostMenuEventSystem.SetActive(value);
    }
    public void Lost()
    {

        SetActiveMenuItems(true);
        levelExtras.GetComponent<LevelTimeScale>().StopLevel();
    }
    public void Retry()
    {
        levelExtras.GetComponent<SpawnSystem>().SendPlayersToSpawnsPositions();
        levelExtras.GetComponent<LevelTimeScale>().StartLevel();
        SetActiveMenuItems(false);
    }
}
