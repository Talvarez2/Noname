using UnityEngine;

/// <summary>
/// Moves an object along a path defined by child Node components.
/// Loops back to the first node after reaching the last.
/// </summary>
public class PathFollower : MonoBehaviour
{
    public float moveSpeed;

    private Node[] _pathNodes;
    private float _startTime;
    private Vector3 _initialPosition;
    private Vector3 _targetPosition;
    private float _totalDistance;
    private int _currentNode;

    private void Start()
    {
        _pathNodes = transform.parent.GetComponentsInChildren<Node>();
        AdvanceToNextNode();
    }

    private void Update()
    {
        float coveredDistance = (Time.time - _startTime) * moveSpeed;

        if (transform.position != _targetPosition)
        {
            transform.position = Vector3.Lerp(_initialPosition, _targetPosition, coveredDistance / _totalDistance);
        }
        else
        {
            AdvanceToNextNode();
        }
    }

    private void AdvanceToNextNode()
    {
        _startTime = Time.time;
        _initialPosition = transform.position;
        _currentNode = (_currentNode + 1) % _pathNodes.Length;
        _targetPosition = _pathNodes[_currentNode].transform.position;
        _totalDistance = Vector3.Distance(_initialPosition, _targetPosition);
    }
}
