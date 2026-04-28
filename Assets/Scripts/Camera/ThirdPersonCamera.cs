using UnityEngine;

/// <summary>
/// Camera that follows the midpoint between both players with smooth interpolation.
/// </summary>
public class ThirdPersonCamera : MonoBehaviour
{
    [Range(0, 1)] public float lerpValue;
    public bool x_track = false;
    public Vector3 _offset = new Vector3(0f, 0f, -10f);
    public GameObject player_1;
    public GameObject player_2;

    private void Update()
    {
        Vector3 midpoint = (player_1.transform.position + player_2.transform.position) / 2f;
        Vector3 targetPosition = x_track
            ? new Vector3(midpoint.x, midpoint.y, 0f)
            : new Vector3(0f, midpoint.y, 0f);
        transform.position = Vector3.Lerp(transform.position, targetPosition + _offset, lerpValue);
    }
}
