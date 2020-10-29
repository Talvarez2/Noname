using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpawnPoint")
        {
            int playerNum = GetComponent<PlayerData>().playerNum;
            GameObject levelExtras = GameObject.FindWithTag("LevelExtras");
            levelExtras.GetComponent<SpawnSystem>().UpdateLastPlayerPoint(playerNum, other.gameObject);
        }
    }
}
