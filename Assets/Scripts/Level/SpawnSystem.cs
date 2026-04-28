using UnityEngine;

/// <summary>
/// Tracks checkpoint progress for both players and handles respawning.
/// Checkpoints are confirmed (turn red) when both players reach the same checkpoint group.
/// </summary>
public class SpawnSystem : MonoBehaviour
{
    public GameObject startPositionPlayer1;
    public GameObject startPositionPlayer2;

    private GameObject[] _playerStartPosition = { null, null };
    private GameObject[] _actualPlayerSpawnPoint = { null, null };
    private GameObject[] _lastPlayerSpawnPoint = { null, null };
    private int[] _playerLifeAtActualSpawn = { 100, 100 };
    private int[] _playerLifeAtLastSpawn = { 100, 100 };

    private void Start()
    {
        _playerStartPosition[0] = startPositionPlayer1;
        _playerStartPosition[1] = startPositionPlayer2;
        _actualPlayerSpawnPoint[0] = startPositionPlayer1;
        _actualPlayerSpawnPoint[1] = startPositionPlayer2;
        _lastPlayerSpawnPoint[0] = startPositionPlayer1;
        _lastPlayerSpawnPoint[1] = startPositionPlayer2;
        startPositionPlayer1.GetComponent<SpawnPoint>().ChangeColor("red");
        startPositionPlayer2.GetComponent<SpawnPoint>().ChangeColor("red");
    }

    /// <summary>
    /// Updates the last spawn point for a player and confirms the checkpoint
    /// if both players have reached the same checkpoint group.
    /// </summary>
    public void UpdateLastPlayerSpawnPoint(int playerNum, GameObject spawnPoint, int playerLife)
    {
        int index = playerNum - 1;

        SpawnPoint lastSpawn = _lastPlayerSpawnPoint[index].GetComponent<SpawnPoint>();
        if (lastSpawn.GetColor() != "red")
        {
            lastSpawn.ChangeColor("blue");
        }
        spawnPoint.GetComponent<SpawnPoint>().ChangeColor("green");

        _lastPlayerSpawnPoint[index] = spawnPoint;
        _playerLifeAtLastSpawn[index] = playerLife;

        if (_lastPlayerSpawnPoint[0].transform.parent == _lastPlayerSpawnPoint[1].transform.parent)
        {
            _actualPlayerSpawnPoint[0].GetComponent<SpawnPoint>().ChangeColor("blue");
            _actualPlayerSpawnPoint[1].GetComponent<SpawnPoint>().ChangeColor("blue");
            _lastPlayerSpawnPoint[0].GetComponent<SpawnPoint>().ChangeColor("red");
            _lastPlayerSpawnPoint[1].GetComponent<SpawnPoint>().ChangeColor("red");

            _actualPlayerSpawnPoint[0] = _lastPlayerSpawnPoint[0];
            _actualPlayerSpawnPoint[1] = _lastPlayerSpawnPoint[1];
            _playerLifeAtActualSpawn[0] = _playerLifeAtLastSpawn[0];
            _playerLifeAtActualSpawn[1] = _playerLifeAtLastSpawn[1];
        }
    }

    /// <summary>
    /// Teleports both players to their last confirmed spawn positions and restores their health.
    /// </summary>
    public void SendPlayersToLastSpawnsPositions()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            int index = player.GetComponent<PlayerData>().playerNum - 1;
            player.GetComponent<HealthAndDamage>().SetLife(_playerLifeAtLastSpawn[index]);

            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false;
            cc.transform.position = _actualPlayerSpawnPoint[index].transform.position;
            cc.enabled = true;
        }
    }

    /// <summary>
    /// Teleports both players to their initial start positions and resets their health.
    /// </summary>
    public void SendPlayersToInitialSpawnsPositions()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            int index = player.GetComponent<PlayerData>().playerNum - 1;
            player.GetComponent<HealthAndDamage>().RestartLife();

            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false;
            cc.transform.position = _playerStartPosition[index].transform.position;
            cc.enabled = true;
        }
    }
}
