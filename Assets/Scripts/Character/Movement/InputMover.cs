using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reads horizontal input for the player and converts it into movement.
/// Applies reduced speed when the player is on an ice floor.
/// </summary>
public class InputMover : MonoBehaviour
{
    public Camera mainCamera;
    public float playerSpeed = 5f;
    public float playerSpeedOnIce = 0.1f;

    private MovementManager _manager;
    private IDictionary<string, Vector3[]> _movement;
    private Vector3[] _moveInfo = { new Vector3(), new Vector3(), new Vector3() };
    private Vector3 _camRight;

    private void Start()
    {
        _manager = GetComponent<MovementManager>();
        _movement = _manager.Vector3Stack;
        _movement.Add("InputMover", _moveInfo);
        _camRight = mainCamera.transform.right;
    }

    private void Update()
    {
        int playerNum = GetComponentInParent<PlayerData>().playerNum;
        string axis = playerNum == 1 ? "P1_Horizontal" : "P2_Horizontal";
        float horizontalMove = Input.GetAxis(axis);

        Vector3 playerInput = new Vector3(horizontalMove, 0f, 0f);
        bool isOnIce = GetComponentInParent<PlayerData>().isOnIceFloor;
        float speed = isOnIce ? playerSpeedOnIce : playerSpeed;

        _moveInfo[0] = playerInput.x * _camRight * speed;
        _movement["InputMover"] = _moveInfo;

        _manager.playerAnimatorController.SetFloat("WalkVelocity", playerInput.magnitude * playerSpeed);
        _manager.playerAnimatorController.SetBool("Left", playerInput.x < 0f);
    }
}
