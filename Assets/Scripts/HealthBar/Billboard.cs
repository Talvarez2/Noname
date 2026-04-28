using UnityEngine;

/// <summary>
/// Keeps the health bar billboard always facing the main camera.
/// </summary>
public class Billboard : MonoBehaviour
{
    private Transform _cam;

    private void Start()
    {
        _cam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _cam.forward);
    }
}
