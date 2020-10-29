using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject startPositionPlayer1;
    public GameObject startPositionPlayer2;
    private GameObject[] actualPlayerSpawnPoint = { null, null };
    private GameObject[] lastPlayerPoint = { null, null };


    private void Start()
    {
        actualPlayerSpawnPoint[0] = startPositionPlayer1;
        actualPlayerSpawnPoint[1] = startPositionPlayer2;
        lastPlayerPoint[0] = startPositionPlayer1;
        lastPlayerPoint[1] = startPositionPlayer2;
    }
    public void UpdateLastPlayerPoint(int playerNum, GameObject spawnPoint)
    {
        lastPlayerPoint[playerNum - 1] = spawnPoint;
        if (lastPlayerPoint[0].transform.parent == lastPlayerPoint[1].transform.parent)
        {
            actualPlayerSpawnPoint[0] = lastPlayerPoint[0];
            actualPlayerSpawnPoint[1] = lastPlayerPoint[1];
        }
    }

    public void SendPlayersToSpawnsPositions()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            player.GetComponent<HealthAndDamage>().RestartLife();
            int playerNum = player.GetComponent<PlayerData>().playerNum;

            CharacterController playerCharacterController = player.GetComponent<CharacterController>();
            playerCharacterController.enabled = false;
            playerCharacterController.transform.position = actualPlayerSpawnPoint[playerNum - 1].transform.position;
            playerCharacterController.enabled = true;
        }
    }
}
