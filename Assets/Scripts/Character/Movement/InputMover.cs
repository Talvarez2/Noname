using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMover : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCamera;
    [SerializeField] private float playerSpeed = 5;
    public float actualPlayerSpeed;


    private MovementManager manager;

    CharacterController player;
    IDictionary<string, Vector3> movement;


    private float horizontalMove;
    private Vector3 playerInput, camRight, movePlayer;

    void Start()
    {
        actualPlayerSpeed = playerSpeed;
        manager = GetComponent<MovementManager>();
        player = manager.player;
        movement = manager.Vector3Stack;
        movement.Add("InputMover", movePlayer);
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
        movePlayer = playerInput.x * camRight; // + playerInput.z * camForward;  // player moves respect to camera
        manager.playerAnimatorController.SetFloat("WalkVelocity", playerInput.magnitude * playerSpeed);
        manager.playerAnimatorController.SetBool("Left", (playerInput.x < 0));
        movePlayer = movePlayer * actualPlayerSpeed;
        movement["InputMover"] = movePlayer;

    }
}
