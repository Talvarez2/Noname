using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private GameObject spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpawnPoint")
        {
            spawnPoint = other.gameObject;
        }
    }

    public void respawn()
    {
        CharacterController player = GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = spawnPoint.transform.position;
        player.enabled = true;
    }

    public void handleReset()
    {
        GetComponent<HandleDeath>().die();
    }

}
