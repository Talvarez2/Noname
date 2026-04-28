using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Applies jump force when the player presses their jump button while grounded.
/// </summary>
public class JumpMover : MonoBehaviour
{
    public float jumpForce = 10f;

    private MovementManager _manager;
    private Vector3[] _moveInfo = { new Vector3(), new Vector3(), new Vector3() };
    private IDictionary<string, Vector3[]> _movement;
    private int _playerNum;

    private void Start()
    {
        _manager = GetComponent<MovementManager>();
        _movement = _manager.Vector3Stack;
        _movement.Add("JumpMover", _moveInfo);
        _playerNum = GetComponentInParent<PlayerData>().playerNum;
    }

    private void Update()
    {
        Vector3 forceMovement = Vector3.zero;

        if (_manager.player.isGrounded)
        {
            string jumpButton = _playerNum == 1 ? "P1_Jump" : "P2_Jump";
            if (Input.GetButtonDown(jumpButton))
            {
                forceMovement.y = jumpForce;
                _manager.playerAnimatorController.SetTrigger("Jump");
                PlayJumpSound();
            }
        }

        _moveInfo[2] = forceMovement;
        _movement["JumpMover"] = _moveInfo;
    }

    private void PlayJumpSound()
    {
        AudioSource jumpSound = GetComponentInParent<PlayerData>().jumpSound;
        if (!jumpSound.isPlaying)
        {
            jumpSound.Play();
        }
    }
}
