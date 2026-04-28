using UnityEngine;

/// <summary>
/// Handles trigger collisions for the player character, including checkpoints,
/// exit doors, and ice floor detection.
/// </summary>
public class ColliderController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int playerNum = GetComponent<PlayerData>().playerNum;
        GameObject levelExtras = GameObject.FindWithTag("LevelExtras");

        if (other.CompareTag("SpawnPoint"))
        {
            int playerLife = GetComponent<HealthAndDamage>().GetActualLife();
            levelExtras.GetComponent<SpawnSystem>().UpdateLastPlayerSpawnPoint(playerNum, other.gameObject, playerLife);
            other.gameObject.GetComponent<SpawnPoint>().ActivateAudio();
        }

        if (other.CompareTag("ExitDoor"))
        {
            levelExtras.GetComponent<WinSystem>().UpdatePlayerOnExitDoor(playerNum);
        }

        if (other.CompareTag("IceFloor"))
        {
            GetComponent<PlayerData>().isOnIceFloor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ExitDoor"))
        {
            int playerNum = GetComponent<PlayerData>().playerNum;
            GameObject levelExtras = GameObject.FindWithTag("LevelExtras");
            levelExtras.GetComponent<WinSystem>().UpdatePlayerOnExitDoor(playerNum);
        }

        if (other.CompareTag("IceFloor"))
        {
            GetComponent<PlayerData>().isOnIceFloor = false;
        }
    }
}
