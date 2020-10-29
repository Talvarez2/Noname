using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMover : MonoBehaviour
{
    public float jumpForce = 10;

    private float fallVelocity;
    private MovementManager manager;
    private Vector3 movePlayer;

    CharacterController player;
    IDictionary<string, Vector3> movement;


    void Start()
    {
        manager = GetComponent<MovementManager>();
        player = manager.player;
        movement = manager.Vector3Stack;
        movement.Add("JumpMover", movePlayer);
    }

    void Update()
    {
        int playerNum = GetComponentInParent<PlayerData>().playerNum;
        if (player.isGrounded && playerNum == 1)
        {
            if (Input.GetButtonDown("P1_Jump")) fallVelocity = jumpForce;
            else fallVelocity = 0;

        }
        else if (player.isGrounded && playerNum == 2)
        {
            if (Input.GetButtonDown("P2_Jump")) fallVelocity = jumpForce;
            else fallVelocity = 0;
        }
        movePlayer.y = fallVelocity;
        movement["JumpMover"] = movePlayer;
    }


}