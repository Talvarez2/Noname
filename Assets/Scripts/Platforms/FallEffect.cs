using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEffect : MonoBehaviour
{
    public int timeBeforeFall = 5;
    public int timeBeforeDestroy = 2;
    public int timeBeforeReapear = 10;
    BoxCollider m_Collider;
    MeshRenderer m_Renderer;
    Rigidbody rigidBody;
    private MeshRenderer meshRenderer;
    private Vector3 startPostition;
    private bool shuffleColor = true;

    private void Start() 
    {
        // Fetch the Collider from the GameObject
        m_Collider = GetComponent<BoxCollider>();
        m_Renderer = GetComponent<MeshRenderer>();
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        startPostition = this.transform.position;
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
            shuffleColor = true;
            StartCoroutine(Fall());
            StartCoroutine(Destroy());
        }
    }

    private void restart(){
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
        m_Renderer.enabled = true;
        m_Collider.enabled = true;
        this.transform.position = startPostition;
        shuffleColor = false;
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
        while (shuffleColor)
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
        m_Renderer.enabled = false;
        m_Collider.enabled = false;
        // Destroy(this.gameObject);
        yield return new WaitForSeconds(timeBeforeFall+timeBeforeDestroy+timeBeforeReapear);
        restart();
    }
}
