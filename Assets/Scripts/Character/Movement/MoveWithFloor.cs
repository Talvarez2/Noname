using UnityEngine;

/// <summary>
/// Moves the player along with moving platforms by tracking the ground object's
/// position and rotation changes each frame.
/// </summary>
public class MoveWithFloor : MonoBehaviour
{
    private CharacterController _player;
    private Vector3 _lastGroundPosition;
    private string _lastGroundName;
    private Quaternion _lastGroundRotation;

    private void Start()
    {
        _player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_player.isGrounded)
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, _player.height / 4.2f, -transform.up, out hit))
            {
                GameObject ground = hit.collider.gameObject;
                string groundName = ground.name;
                Vector3 groundPosition = ground.transform.position;
                Quaternion groundRotation = ground.transform.rotation;

                if (groundPosition != _lastGroundPosition && groundName == _lastGroundName)
                {
                    transform.position += groundPosition - _lastGroundPosition;
                }

                if (groundRotation != _lastGroundRotation && groundName == _lastGroundName)
                {
                    var rotationDelta = transform.rotation * (groundRotation.eulerAngles - _lastGroundRotation.eulerAngles);
                    transform.RotateAround(ground.transform.position, Vector3.up, rotationDelta.y);
                }

                _lastGroundName = groundName;
                _lastGroundPosition = groundPosition;
                _lastGroundRotation = groundRotation;
            }
        }
        else
        {
            _lastGroundName = null;
            _lastGroundPosition = Vector3.zero;
            _lastGroundRotation = Quaternion.identity;
        }
    }

    private void OnDrawGizmos()
    {
        CharacterController player = GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, player.height / 4.2f);
    }
}
