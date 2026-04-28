using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Applies momentum-based sliding movement when the player is on an ice floor.
/// Gradually accelerates and decelerates based on input.
/// </summary>
public class IceMover : MonoBehaviour
{
    public int ice_speed_limit = 5;
    public float speed_change = 0.08f;

    private MovementManager _manager;
    private Vector3[] _moveInfo = { new Vector3(), new Vector3(), new Vector3() };
    private Vector3 _actualForceMovement;
    private IDictionary<string, Vector3[]> _movement;
    private CharacterController _player;

    private void Start()
    {
        _manager = GetComponent<MovementManager>();
        _player = _manager.player;
        _movement = _manager.Vector3Stack;
        _movement.Add("IceMover", _moveInfo);
    }

    private void Update()
    {
        int playerNum = GetComponentInParent<PlayerData>().playerNum;
        bool isOnIce = GetComponentInParent<PlayerData>().isOnIceFloor;

        if (isOnIce)
        {
            string axis = playerNum == 1 ? "P1_Horizontal" : "P2_Horizontal";
            float inputForce = Input.GetAxis(axis) * speed_change;

            _actualForceMovement.x += inputForce;

            // Apply friction when no input
            if (Mathf.Approximately(inputForce, 0f))
            {
                if (_actualForceMovement.x > speed_change)
                    _actualForceMovement.x -= speed_change / 2f;
                else if (_actualForceMovement.x < -speed_change)
                    _actualForceMovement.x += speed_change / 2f;
                else
                    _actualForceMovement.x = 0f;
            }

            // Clamp to speed limit
            _actualForceMovement.x = Mathf.Clamp(_actualForceMovement.x, -ice_speed_limit, ice_speed_limit);
        }
        else
        {
            _actualForceMovement.x = 0f;
        }

        _moveInfo[0] = _actualForceMovement;
        _movement["IceMover"] = _moveInfo;
    }
}
