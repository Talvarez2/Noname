using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows a player to pull the other player toward them via the rope.
/// Applies a force impulse in the direction from the other player to this player.
/// </summary>
public class PullRopeMover : MonoBehaviour
{
    public float pullForce = 10f;
    [SerializeField] private float pullCooldown = 1f;

    private Vector3[] _moveInfo = { new Vector3(), new Vector3(), new Vector3() };
    private IDictionary<string, Vector3[]> _movement;
    private CharacterController _player;
    private CharacterController _otherPlayer;
    private float _lastPullTime;

    private void Start()
    {
        _player = GetComponent<MovementManager>().player;
        _otherPlayer = GetComponent<RopeMover>().otherPlayer;
        MovementManager otherManager = _otherPlayer.gameObject.GetComponentInChildren<MovementManager>();
        _movement = otherManager.Vector3Stack;
        _movement.Add("PullRopeMover", _moveInfo);
        _lastPullTime = Time.time;
    }

    private void Update()
    {
        Vector3 forceMovement = Vector3.zero;

        if (Time.time - _lastPullTime > pullCooldown && _player.isGrounded)
        {
            int playerNum = GetComponentInParent<PlayerData>().playerNum;
            string pullButton = playerNum == 1 ? "P1_Pull" : "P2_Pull";

            if (Input.GetButtonDown(pullButton))
            {
                Vector3 direction = (_player.transform.position - _otherPlayer.transform.position).normalized;
                forceMovement = direction * pullForce;
                _lastPullTime = Time.time;
            }
        }

        _moveInfo[2] = forceMovement;
        _movement["PullRopeMover"] = _moveInfo;
    }
}
