using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject startPositionPlayer1;
    public GameObject startPositionPlayer2;
    private GameObject[] playerStartPosition = { null, null};
    private GameObject[] actualPlayerSpawnPoint = { null, null };
    private GameObject[] lastPlayerSpawnPoint = { null, null };
    private int[] playerLifeInActualSpawnPoint = { 100, 100};
    private int[] playerLifeInLastSpawnPoint = { 100, 100 };

    private void Start()
    {
        playerStartPosition[0] = startPositionPlayer1;
        playerStartPosition[1] = startPositionPlayer2;
        actualPlayerSpawnPoint[0] = startPositionPlayer1;
        actualPlayerSpawnPoint[1] = startPositionPlayer2;
        lastPlayerSpawnPoint[0] = startPositionPlayer1;
        lastPlayerSpawnPoint[1] = startPositionPlayer2;
    }

    public void UpdateLastPlayerSpawnPoint(int playerNum, GameObject spawnPoint, int playerLife)
    {
        int index = playerNum - 1;
        lastPlayerSpawnPoint[index] = spawnPoint;
        playerLifeInLastSpawnPoint[index] = playerLife;
        if (lastPlayerSpawnPoint[0].transform.parent == lastPlayerSpawnPoint[1].transform.parent)
        {
            actualPlayerSpawnPoint[0] = lastPlayerSpawnPoint[0];
            actualPlayerSpawnPoint[1] = lastPlayerSpawnPoint[1];
            playerLifeInActualSpawnPoint[0] = playerLifeInLastSpawnPoint[0];
            playerLifeInActualSpawnPoint[1] = playerLifeInLastSpawnPoint[1];
        }
    }

    public void SendPlayersToLastSpawnsPositions()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            int playerNum = player.GetComponent<PlayerData>().playerNum;
            int index = playerNum - 1;

            player.GetComponent<HealthAndDamage>().SetLife(playerLifeInLastSpawnPoint[index]);

            CharacterController playerCharacterController = player.GetComponent<CharacterController>();
            playerCharacterController.enabled = false;
            playerCharacterController.transform.position = actualPlayerSpawnPoint[index].transform.position;
            playerCharacterController.enabled = true;
        }
    }

    public void SendPlayersToInitialSpawnsPositions()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            int playerNum = player.GetComponent<PlayerData>().playerNum;
            int index = playerNum - 1;

            player.GetComponent<HealthAndDamage>().RestartLife();

            CharacterController playerCharacterController = player.GetComponent<CharacterController>();
            playerCharacterController.enabled = false;
            playerCharacterController.transform.position = playerStartPosition[index].transform.position;
            playerCharacterController.enabled = true;
        }
    }
}
