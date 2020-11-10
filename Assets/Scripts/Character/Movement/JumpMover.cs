using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMover : MonoBehaviour
{
    public float jumpForce = 10;

    private float fallVelocity;
    private MovementManager manager;
    private Vector3[] moveInfo = {new Vector3(), new Vector3(), new Vector3()};
    private Vector3 forceMovement = new Vector3();

    CharacterController player;
    IDictionary<string, Vector3[]> movement;


    void Start()
    {
        manager = GetComponent<MovementManager>();
        player = manager.player;
        movement = manager.Vector3Stack;
        movement.Add("JumpMover", moveInfo);
    }

    void Update()
    {
        forceMovement = new Vector3();

        int playerNum = GetComponentInParent<PlayerData>().playerNum;
        if (player.isGrounded && playerNum == 1)
        {
            if (Input.GetButtonDown("P1_Jump")) {
                forceMovement.y = jumpForce;
                manager.playerAnimatorController.SetTrigger("Jump");
            }    

        }
        else if (player.isGrounded && playerNum == 2)
        {
            if (Input.GetButtonDown("P2_Jump")){
                forceMovement.y = jumpForce;
                manager.playerAnimatorController.SetTrigger("Jump");
            }
        }
        moveInfo[2] = forceMovement;
        movement["JumpMover"] = moveInfo;
    }


}