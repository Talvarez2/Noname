using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private CharacterController player;

    public void spawn(GameObject character)
    {
        player = character.GetComponent<CharacterController>();
        Debug.Log("respawn");
        player.enabled = false;
        player.transform.position = transform.position;
        player.enabled = true;
    }
}
