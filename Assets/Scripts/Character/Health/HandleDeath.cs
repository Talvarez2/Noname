using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    public void die()
    {
        GetComponent<HealthAndDamage>().RestartLife();
        GetComponent<Spawn>().respawn();
    }
}
