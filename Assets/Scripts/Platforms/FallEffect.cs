using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEffect : MonoBehaviour
{
    public int timeBeforeFall = 5;
    public int timeBeforeDestroy = 1;
    public int timeToRespawn = 1;
    BoxCollider m_Collider;
    MeshRenderer m_Renderer;
    Rigidbody rigidBody;
    private MeshRenderer meshRenderer;
    public bool respawn = false;
    private Vector3 respawnPosition;
    private Quaternion respawnRotation;
    private BoxCollider boxCollider;
    private bool toogle = false;

    private void Start() 
    {
        // Fetch the Collider from the GameObject
        m_Collider = GetComponent<BoxCollider>();
        boxCollider = gameObject.AddComponent<BoxCollider>();
        rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        rigidBody.useGravity = false;
        boxCollider.size = new Vector3(1, 2, 1);
        boxCollider.isTrigger = true;
        meshRenderer = GetComponent<MeshRenderer>();
        if (respawn == true) {
            respawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            respawnRotation = new Quaternion(this.transform.rotation.w,this.transform.rotation.x, this.transform.rotation.y,this.transform.rotation.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            toogle = true;
            StartCoroutine(ToogleImageSize());
            StartCoroutine(Fall());
            StartCoroutine(Destroy());
            if (respawn == true) {
                StartCoroutine(Respawn());
            }
        }
    }

    private void restart(){
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
        m_Renderer.enabled = true;
        m_Collider.enabled = true;
        this.transform.position = respawnPosition;
        toogle = false;
        meshRenderer.material.color = new Color(1, 1, 1, 0_01f);

    }

    IEnumerator Fall()
    {
        // wait and then fall
        Debug.Log("fall");
        yield return new WaitForSeconds(timeBeforeFall);
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
    }

    IEnumerator ToogleImageSize()
    {
        while (toogle)
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
        if (respawn == true) {
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            m_Collider.enabled = false;
        } else {
            Destroy(this.gameObject);
        }
    }


    IEnumerator Respawn()
    {
        // wait and then destroy
        yield return new WaitForSeconds(timeBeforeFall+timeBeforeDestroy+timeToRespawn);
        toogle = false;
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
        this.transform.position = respawnPosition;
        this.transform.rotation = respawnRotation;
        meshRenderer.enabled = true;
        boxCollider.enabled = true;
        m_Collider.enabled = true;
    }
}
