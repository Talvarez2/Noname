﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostMenu : MonoBehaviour
{
    public GameObject lostMenuUI;
    public GameObject lostMenuCamera;
    public GameObject lostMenuEventSystem;
    private GameObject levelExtras;

    private void SetActiveMenuItems(bool value)
    {
        lostMenuUI.SetActive(value);
        lostMenuCamera.SetActive(value);
        lostMenuEventSystem.SetActive(value);
    }
    public void Lost()
    {
        SetActiveMenuItems(true);
        levelExtras = GameObject.FindWithTag("LevelExtras");
        levelExtras.GetComponent<LevelTimeScale>().StopLevel();
    }
    public void Continue()
    {
        levelExtras.GetComponent<SpawnSystem>().SendPlayersToLastSpawnsPositions();
        levelExtras.GetComponent<LevelTimeScale>().StartLevel();
        SetActiveMenuItems(false);
    }
    public void Retry()
    {
        levelExtras.GetComponent<SpawnSystem>().SendPlayersToInitialSpawnsPositions();
        levelExtras.GetComponent<LevelTimeScale>().StartLevel();
        SetActiveMenuItems(false);
    }
}
