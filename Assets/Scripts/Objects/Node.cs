using UnityEngine;

/// <summary>
/// Waypoint node used by PathFollower to define movement paths.
/// Draws a blue gizmo sphere in the editor for visualization.
/// </summary>
public class Node : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
