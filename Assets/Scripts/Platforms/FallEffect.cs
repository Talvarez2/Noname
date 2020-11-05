using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEffect : MonoBehaviour
{
    public int timeBeforeFall = 5;
    public int timeBeforeDestroy = 1;
    BoxCollider m_Collider;
    Rigidbody rigidBody;

    private void Start() 
    {
        // Fetch the Collider from the GameObject
        m_Collider = GetComponent<BoxCollider>();
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        rigidBody.useGravity = false;
        boxCollider.size = new Vector3(1, 5, 1);
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            StartCoroutine(Fall());
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Fall()
    {
        // wait and then fall
        yield return new WaitForSeconds(timeBeforeFall);
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
    }

    IEnumerator Destroy()
    {
        // wait and then destroy
        yield return new WaitForSeconds(timeBeforeFall+timeBeforeDestroy);
        Destroy(this.gameObject);
    }
}
