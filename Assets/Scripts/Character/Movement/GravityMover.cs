using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Applies constant downward gravity to the player. When grounded, applies a small
/// downward force to keep the CharacterController snapped to the ground.
/// </summary>
public class GravityMover : MonoBehaviour
{
    public float gravity = 10f;

    private MovementManager _manager;
    private Vector3[] _moveInfo = { new Vector3(), new Vector3(), new Vector3() };
    private IDictionary<string, Vector3[]> _movement;
    private CharacterController _player;

    private void Start()
    {
        _manager = GetComponent<MovementManager>();
        _player = _manager.player;
        _movement = _manager.Vector3Stack;
        _movement.Add("GravityMover", _moveInfo);
    }

    private void Update()
    {
        Vector3 staticMovement = Vector3.zero;
        Vector3 dynamicMovement = Vector3.zero;

        if (_player.isGrounded)
            staticMovement.y = -2f;
        else
            dynamicMovement.y = -gravity;

        _moveInfo[0] = staticMovement;
        _moveInfo[1] = dynamicMovement;
        _movement["GravityMover"] = _moveInfo;
    }
}
