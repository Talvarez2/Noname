﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRopeMover : MonoBehaviour
{
    public float pullForce = 10;
    private Vector3[] moveInfo = { new Vector3(), new Vector3(), new Vector3() };
    private MovementManager otherManager;
    private Vector3 forceMovement;
    [SerializeField] private float pullCooldown = 1f;
    private float lastPullTime;
    IDictionary<string, Vector3[]> movement;

    CharacterController player;
    CharacterController otherPlayer;


    void Start()
    {
        player = GetComponent<MovementManager>().player;
        otherPlayer = GetComponent<RopeMover>().otherPlayer;
        otherManager = otherPlayer.gameObject.GetComponentInChildren<MovementManager>();
        movement = otherManager.Vector3Stack;
        movement.Add("PullRopeMover", moveInfo);
        lastPullTime = Time.time;
    }

    void Update()
    {
        forceMovement = new Vector3();
        int playerNum = GetComponentInParent<PlayerData>().playerNum;

        if (Time.time - lastPullTime > pullCooldown)
        {
            if (player.isGrounded && playerNum == 1)
            {
                if (Input.GetButtonDown("P1_Pull"))
                {
                    forceMovement = GetForceMovement();
                }

            }
            else if (player.isGrounded && playerNum == 2)
            {
                if (Input.GetButtonDown("P2_Pull"))
                {
                    forceMovement = GetForceMovement();
                }
            }
        }


        moveInfo[2] = forceMovement;
        movement["PullRopeMover"] = moveInfo;
    }

    private Vector3 GetForceMovement()
    {
        Vector3 direction = player.transform.position - otherPlayer.transform.position;
        direction.Normalize();
        forceMovement = direction * pullForce;
        lastPullTime = Time.time;
        return forceMovement;
    }

}
