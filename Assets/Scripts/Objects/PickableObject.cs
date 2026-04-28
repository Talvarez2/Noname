using UnityEngine;

/// <summary>
/// Marks an object as pickable by players. Notifies the player's PickUpObjects
/// component when entering or exiting the interaction zone.
/// </summary>
public class PickableObject : MonoBehaviour
{
    public bool isPickable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerInteractionZone"))
        {
            other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerInteractionZone"))
        {
            other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = null;
        }
    }
}
