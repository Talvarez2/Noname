using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEffect : MonoBehaviour
{
    public int timeBeforeFall = 5;
    public int timeBeforeDestroy = 1;
    BoxCollider m_Collider;
    Rigidbody rigidBody;
    private MeshRenderer meshRenderer;

    private void Start() 
    {
        // Fetch the Collider from the GameObject
        m_Collider = GetComponent<BoxCollider>();
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        rigidBody.useGravity = false;
        boxCollider.size = new Vector3(1, 2, 1);
        boxCollider.isTrigger = true;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            StartCoroutine(ToogleImageSize());
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

    IEnumerator ToogleImageSize()
    {
        while (true)
        {
            meshRenderer.material.color = Color.red;
            yield return new WaitForSeconds(0.2F);
            meshRenderer.material.color = new Color(1, 1, 1, 0_01f);
            yield return new WaitForSeconds(0.2F);
        }
    }

    IEnumerator Destroy()
    {
        // wait and then destroy
        yield return new WaitForSeconds(timeBeforeFall+timeBeforeDestroy);
        Destroy(this.gameObject);
    }
}
