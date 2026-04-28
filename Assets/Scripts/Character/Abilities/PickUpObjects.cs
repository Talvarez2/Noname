using UnityEngine;

/// <summary>
/// Allows the player to pick up and drop objects using the Fire1 input button.
/// </summary>
public class PickUpObjects : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public Transform InteractionZone;

    private GameObject _pickedObject;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_pickedObject != null)
            {
                DropObject();
            }
            else if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable)
            {
                PickUp();
            }
        }
    }

    private void PickUp()
    {
        _pickedObject = ObjectToPickUp;
        _pickedObject.GetComponent<PickableObject>().isPickable = false;
        _pickedObject.transform.SetParent(InteractionZone);
        _pickedObject.transform.position = InteractionZone.position;

        Rigidbody rb = _pickedObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    private void DropObject()
    {
        _pickedObject.GetComponent<PickableObject>().isPickable = true;
        _pickedObject.transform.SetParent(null);

        Rigidbody rb = _pickedObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;

        _pickedObject = null;
    }
}
