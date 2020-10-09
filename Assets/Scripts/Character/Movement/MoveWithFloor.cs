using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloor : MonoBehaviour
{
    CharacterController player;

    Vector3 groundPosition;
    Vector3 lastGoundPosition;
    string GroundName;
    string LastGroundName;
    Quaternion actualRot;
    Quaternion lastRot;



    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded)
        {
            RaycastHit hit;

            if(Physics.SphereCast(transform.position, player.height /4.2f, -transform.up, out hit))
            {
                GameObject groundedIn = hit.collider.gameObject;
                GroundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                actualRot = groundedIn.transform.rotation;

                if (groundPosition != lastGoundPosition && GroundName == LastGroundName){
                    this.transform.position += groundPosition - lastGoundPosition;
                }

                if (actualRot != lastRot && GroundName == LastGroundName){
                    var newRot = this.transform.rotation * (actualRot.eulerAngles - lastRot.eulerAngles);
                    this.transform.RotateAround(groundedIn.transform.position, Vector3.up, newRot.y);
                }

                LastGroundName = GroundName;
                lastGoundPosition = groundPosition;
                lastRot = actualRot;
            }

        }
        else if (!player.isGrounded)
        {
            LastGroundName = null;
            lastGoundPosition = Vector3.zero;
            lastRot = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnDrawGizmos() {
        player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, player.height / 4.2f);
    }
}
