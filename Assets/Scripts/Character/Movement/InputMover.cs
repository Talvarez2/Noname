﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMover : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerNum = 1;
    public Camera mainCamera;
    public float playerSpeed = 5;
    

    private MovementManager manager;
    
    CharacterController player;
    IDictionary<string, Vector3> movement;


    private float horizontalMove;
    private Vector3 playerInput, camRight, movePlayer;

    void Start()
    {   
        manager = GetComponent<MovementManager>(); 
        player = manager.player;
        movement = manager.Vector3Stack;
        movement.Add("InputMover",movePlayer);
        camRight = mainCamera.transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNum == 1)
        {
            horizontalMove = Input.GetAxis("P1_Horizontal");    
        }
        else
        {
            horizontalMove = Input.GetAxis("P2_Horizontal");
        }
        playerInput = new Vector3(horizontalMove, 0, 0);
        movePlayer = playerInput.x * camRight; // + playerInput.z * camForward;  // player moves respect to camera

        movePlayer = movePlayer * playerSpeed;
        movement["InputMover"] = movePlayer;

    }
}