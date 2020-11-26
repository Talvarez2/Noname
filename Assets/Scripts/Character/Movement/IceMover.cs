using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMover : MonoBehaviour
{
    private MovementManager manager;
    private Vector3[] moveInfo = { new Vector3(), new Vector3(), new Vector3() };
    private Vector3 actualForceMovement = new Vector3();
    private Vector3 newForceMovement = new Vector3();
    IDictionary<string, Vector3[]> movement;
    CharacterController player;

    void Start()
    {
        manager = GetComponent<MovementManager>();
        player = manager.player;
        movement = manager.Vector3Stack;
        movement.Add("IceMover", moveInfo);
    }
    void Update()
    {
        int playerNum = GetComponentInParent<PlayerData>().playerNum;
        bool playerOnIceFloor = GetComponentInParent<PlayerData>().isOnIceFloor;

        if (playerOnIceFloor && player.isGrounded)
        {
            if (playerNum == 1)
            {
                newForceMovement.x = Input.GetAxis("P1_Horizontal") / 5;
            }
            else if (playerNum == 2)
            {
                newForceMovement.x = Input.GetAxis("P2_Horizontal") / 5;
            }

            actualForceMovement = actualForceMovement + newForceMovement;
            if (newForceMovement.x == 0)
            {
                if (actualForceMovement.x > 0.1f)
                {
                    actualForceMovement.x -= 0.1f;
                }
                else if (actualForceMovement.x < -0.1f)
                {
                    actualForceMovement.x += 0.1f;
                }
                else
                {
                    actualForceMovement.x = 0;
                }
            }
            else
            {
                if (actualForceMovement.x > 7)
                {
                    actualForceMovement.x = 7;
                }
                else if (actualForceMovement.x < -7)
                {
                    actualForceMovement.x = -7;
                }
            }
        }
        else
        {
            if (actualForceMovement.x != 0)
            {
                actualForceMovement.x = 0;
            }
        }

        moveInfo[2] = actualForceMovement;
        movement["IceMover"] = moveInfo;
    }
}
