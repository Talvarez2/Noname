﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int playerNum = GetComponent<PlayerData>().playerNum;
        GameObject levelExtras = GameObject.FindWithTag("LevelExtras");

        if (other.tag == "SpawnPoint")
        {
            int playerLife = GetComponent<HealthAndDamage>().GetActualLife();
            levelExtras.GetComponent<SpawnSystem>().UpdateLastPlayerSpawnPoint(playerNum, other.gameObject, playerLife);
        }

        if (other.tag == "ExitDoor")
        {
            levelExtras.GetComponent<WinSystem>().UpdatePlayerOnExitDoor(playerNum);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "ExitDoor")
        {
            int playerNum = GetComponent<PlayerData>().playerNum;
            GameObject levelExtras = GameObject.FindWithTag("LevelExtras");
            levelExtras.GetComponent<WinSystem>().UpdatePlayerOnExitDoor(playerNum);
        }
    }
}
