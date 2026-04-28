using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aggregates all movement contributions from mover components each frame
/// and applies the final movement via CharacterController.Move().
/// Each mover registers a Vector3[3] array: [0] static, [1] dynamic, [2] force.
/// </summary>
public class MovementManager : MonoBehaviour
{
    public IDictionary<string, Vector3[]> Vector3Stack = new Dictionary<string, Vector3[]>();
    public CharacterController player;
    public Animator playerAnimatorController;

    private Vector3 _staticMovement;
    private Vector3 _dynamicMovement;
    private Vector3 _forceMovement;
    private Vector3 _totalMovement;
    private bool _ropeOn = true;

    private void Start()
    {
        player = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        playerAnimatorController.SetBool("IsGrounded", player.isGrounded);

        _staticMovement = Vector3.zero;
        if (player.isGrounded) _dynamicMovement = Vector3.zero;
        _forceMovement = Vector3.zero;
        _totalMovement = Vector3.zero;

        foreach (KeyValuePair<string, Vector3[]> kvp in Vector3Stack)
        {
            _staticMovement += kvp.Value[0];
            _dynamicMovement += kvp.Value[1] * Time.deltaTime;
            _forceMovement += kvp.Value[2];
        }

        _dynamicMovement += _forceMovement;
        _totalMovement = _staticMovement + _dynamicMovement;

        if (_ropeOn)
        {
            RopeMover ropeMover = GetComponent<RopeMover>();
            Vector3 projection = ropeMover.CalculateRopeProjection(_totalMovement);
            Vector3 positionDelta = ropeMover.CalculateRopePull(_totalMovement);
            _dynamicMovement -= projection * Time.deltaTime;
            _staticMovement += positionDelta;
            _totalMovement = _staticMovement + _dynamicMovement;
        }

        player.Move(_totalMovement * Time.deltaTime);
    }
}
