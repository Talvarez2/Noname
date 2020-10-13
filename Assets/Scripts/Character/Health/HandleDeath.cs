using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    [SerializeField] public GameObject respawnPoint;

    // private void Start()
    // {
    //     GameObject spawnPosition = GetClosestSpawnPosition();
    //     respawnPoint = spawnPosition;
    // }

    // GameObject GetClosestSpawnPosition()
    // {
    //     List<Transform> spawnPositions = Mirror.NetworkManager.startPositions;
    //     Transform tMin = null;
    //     float minDist = Mathf.Infinity;
    //     Vector3 currentPos = transform.position;
    //     foreach (Transform t in spawnPositions)
    //     {
    //         float dist = Vector3.Distance(t.position, currentPos);
    //         if (dist < minDist)
    //         {
    //             tMin = t;
    //             minDist = dist;
    //         }
    //     }
    //     return tMin.gameObject;
    // }
    public void die()
    {
        GetComponent<HealthAndDamage>().RestartLife();
        respawnPoint.GetComponent<Spawn>().spawn(this.gameObject);
    }
}
