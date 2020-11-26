using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMover : MonoBehaviour
{
    private MovementManager manager;
    private Vector3[] moveInfo = { new Vector3(), new Vector3(), new Vector3() };
    private Vector3 finalForceMovement = new Vector3();
    private Vector3 actualForceMovement = new Vector3();
    private Vector3 newForceMovement = new Vector3();
    private Vector3 input;
    public int ice_speed_limit = 5;
    public float speed_change = 0.08f;
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
        
        if (playerOnIceFloor)
        {
            if (playerNum == 1)
            {
                newForceMovement.x = Input.GetAxis("P1_Horizontal")*speed_change;
            }
            else if (playerNum == 2)
            {
                newForceMovement.x = Input.GetAxis("P2_Horizontal")*speed_change;
            }

            actualForceMovement = actualForceMovement + newForceMovement;
            if (newForceMovement.x == 0)
            {
                if (actualForceMovement.x > speed_change)
                {
                    actualForceMovement.x -= speed_change/2;
                }
                else if (actualForceMovement.x < -speed_change)
                {
                    actualForceMovement.x += speed_change/2;
                }
                else
                {
                    actualForceMovement.x = 0;
                }
            }

            if (actualForceMovement.x > ice_speed_limit)
            {
                actualForceMovement.x = ice_speed_limit;
            }
            else if (actualForceMovement.x < -ice_speed_limit)
            {
                actualForceMovement.x = -ice_speed_limit;
            }
        
        }
        else if (player.isGrounded && !playerOnIceFloor){
            actualForceMovement.x = 0;
        }
        else
        {
            if (actualForceMovement.x != 0)
            {
                actualForceMovement.x = 0;
            }
        }

        moveInfo[0] = actualForceMovement;
        movement["IceMover"] = moveInfo;
    }
}
