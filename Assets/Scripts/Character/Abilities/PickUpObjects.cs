using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{


    public GameObject ObjectToPickUp;
    private GameObject PickedObject;
    public Transform InteractionZone;

    // Update is called once per frame
    void Update()
    {
        if (ObjectToPickUp != null
            && ObjectToPickUp.GetComponent<PickableObject>().isPickable
            && PickedObject == null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                PickedObject.transform.SetParent(InteractionZone);
                PickedObject.transform.position = InteractionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        else if (PickedObject != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }
        }
    }
}
