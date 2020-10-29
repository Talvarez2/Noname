using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        float radius = GetComponent<SphereCollider>().radius;
        Gizmos.DrawSphere(transform.position, radius);
    }

}
