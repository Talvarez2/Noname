using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Constrains player movement when the rope between players is taut.
/// Projects movement away from the other player and pulls the player back within range.
/// </summary>
public class RopeMover : MonoBehaviour
{
    public CharacterController otherPlayer;
    public int maxDist = 30;

    private MovementManager _manager;
    private Vector3[] _moveInfo = { new Vector3(), new Vector3(), new Vector3() };
    private CharacterController _player;
    private IDictionary<string, Vector3[]> _movement;

    private void Start()
    {
        _manager = GetComponent<MovementManager>();
        _player = _manager.player;
        _movement = _manager.Vector3Stack;
        _movement.Add("RopeMover", _moveInfo);
    }

    /// <summary>
    /// Calculates a pull force toward the other player when the rope is taut.
    /// </summary>
    public Vector3 CalculateRopePull(Vector3 potentialMovement)
    {
        float dist = Vector3.Distance(_player.transform.position, otherPlayer.transform.position);
        if (dist <= maxDist)
            return Vector3.zero;

        float angle = Vector3.SignedAngle(
            Vector3.right,
            otherPlayer.transform.position - _player.transform.position,
            Vector3.forward);

        float rad = angle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f);
        return direction * (dist - maxDist) * 100f;
    }

    /// <summary>
    /// Calculates the projection of movement along the rope direction to prevent
    /// the player from moving further away when the rope is taut.
    /// </summary>
    public Vector3 CalculateRopeProjection(Vector3 potentialMovement)
    {
        float dist = Vector3.Distance(_player.transform.position, otherPlayer.transform.position);
        if (dist <= maxDist)
            return Vector3.zero;

        float angle = Vector3.SignedAngle(
            Vector3.right,
            _player.transform.position - otherPlayer.transform.position,
            Vector3.forward);

        float rad = angle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f);

        if (Vector3.Dot(potentialMovement, direction) > 0f)
            return Vector3.Project(potentialMovement, direction) / 2f;

        return Vector3.zero;
    }
}
