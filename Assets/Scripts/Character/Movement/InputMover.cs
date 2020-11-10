using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMover : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCamera;
    public float playerSpeed = 5;


    private MovementManager manager;

    CharacterController player;
    IDictionary<string, Vector3[]> movement;
    private Vector3[] moveInfo = {new Vector3(), new Vector3(), new Vector3()};
    private Vector3 staticMovement = new Vector3();


    private float horizontalMove;
    private Vector3 playerInput, camRight, movePlayer;

    void Start()
    {
        manager = GetComponent<MovementManager>();
        player = manager.player;
        movement = manager.Vector3Stack;
        movement.Add("InputMover", moveInfo);
        camRight = mainCamera.transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        int playerNum = GetComponentInParent<PlayerData>().playerNum;
        if (playerNum == 1)
        {
            horizontalMove = Input.GetAxis("P1_Horizontal");
        }
        else
        {
            horizontalMove = Input.GetAxis("P2_Horizontal");
        }
        playerInput = new Vector3(horizontalMove, 0, 0);
        staticMovement = playerInput.x * camRight * playerSpeed; 

        moveInfo[0] = staticMovement;
        movement["InputMover"] = moveInfo;

        // Animator
        manager.playerAnimatorController.SetFloat("WalkVelocity", playerInput.magnitude * playerSpeed);
        manager.playerAnimatorController.SetBool("Left", (playerInput.x < 0));


    }
}
