using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerNum;
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;

    public CharacterController player;

    public float playerSpeed;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    private float fallVelocity;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    private bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity;
    private float distance;
    public CharacterController otherPlayer;
    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerNum == 1){
            horizontalMove = Input.GetAxis("P1_Horizontal");
            verticalMove = Input.GetAxis("P1_Vertical");
        } else {
            horizontalMove = Input.GetAxis("P2_Horizontal");
            verticalMove = Input.GetAxis("P2_Vertical");
        }
        

        playerInput = new Vector3(horizontalMove, 0, 0);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);  // moves at the same speed diagonally and straight

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;  // player moves respect to camera

        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);  // the player looks where he is moving

        handleGravity();
        SlideDown();
        playerSkills();
        getDistance();

        player.Move(movePlayer * Time.deltaTime);  // player movement
        
    }

    // gets the current camera direction
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void getDistance()
    {
        distance = Vector3.Distance(player.transform.position, otherPlayer.transform.position);
        Debug.Log(distance);
        if (distance >= maxDistance){
            // max distance to the horizontal
            if (player.transform.position.x - otherPlayer.transform.position.x > 0){
                if (movePlayer.x > 0){
                    movePlayer.x = 0;
                }
            } else if (player.transform.position.x - otherPlayer.transform.position.x < 0){
                if (movePlayer.x < 0){
                    movePlayer.x = 0;
                }
            }
            // max distance to the vertical
            if (player.transform.position.y - otherPlayer.transform.position.y > 0){
                if (movePlayer.y > 0){
                    movePlayer.y = 0;
                }
            } else if (player.transform.position.y - otherPlayer.transform.position.y < 0){
                if (movePlayer.y < 0){
                    movePlayer.y = 0;
                }
            }
        }
    }

    // Handles gravity acceleration
    void handleGravity()
    {
        if (player.isGrounded)  // if player is touching not touching the flor it accelerates downwards
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        } else {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    // handle diferent skills of our player
    void playerSkills()
    {
        /*
            implemented skills:
                - jump
        */

        if (player.isGrounded && playerNum == 1 && Input.GetButtonDown("P1_Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        } else if (player.isGrounded && playerNum == 2 && Input.GetButtonDown("P2_Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
        

    }

    public void SlideDown()
    {
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit 
                    && Vector3.Angle(Vector3.up, hitNormal) <= 89f;  // the plane angle is bigger than the player slope limit

        if (isOnSlope)
        {
            movePlayer.x = (1f - hitNormal.y) * hitNormal.x * slideVelocity;
            movePlayer.z = (1f - hitNormal.y) * hitNormal.z * slideVelocity;

            movePlayer.y -= slideVelocity;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;

    }
}
