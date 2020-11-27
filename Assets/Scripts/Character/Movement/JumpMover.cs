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

    private bool playEnabled = false;
    private int playerNum;


    void Start()
    {
        manager = GetComponent<MovementManager>();
        player = manager.player;
        movement = manager.Vector3Stack;
        movement.Add("JumpMover", moveInfo);
        playerNum = GetComponentInParent<PlayerData>().playerNum;

    }

    void Update()
    {
        forceMovement = new Vector3();

        if (player.isGrounded && playerNum == 1)
        {
            if (Input.GetButtonDown("P1_Jump")) {
                forceMovement.y = jumpForce;
                manager.playerAnimatorController.SetTrigger("Jump");
                PlayJumpSound();
            }    

        }
        else if (player.isGrounded && playerNum == 2)
        {
            if (Input.GetButtonDown("P2_Jump")){
                forceMovement.y = jumpForce;
                manager.playerAnimatorController.SetTrigger("Jump");
                PlayJumpSound();
            }
        }

        moveInfo[2] = forceMovement;
        movement["JumpMover"] = moveInfo;
    }

    void PlayJumpSound()
    {
        if (!GetComponentInParent<PlayerData>().jumpSound.isPlaying)
        {
            GetComponentInParent<PlayerData>().jumpSound.Play();
        }
    }

}