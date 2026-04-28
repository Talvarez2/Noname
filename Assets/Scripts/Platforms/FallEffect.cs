using System.Collections;
using UnityEngine;

/// <summary>
/// Falling platform effect: shakes (flashes red), falls after a delay,
/// and optionally respawns after a cooldown.
/// </summary>
public class FallEffect : MonoBehaviour
{
    public int timeBeforeFall = 5;
    public int timeBeforeDestroy = 1;
    public int timeToRespawn = 1;
    public bool respawn = false;

    private BoxCollider _mainCollider;
    private BoxCollider _triggerCollider;
    private Rigidbody _rigidbody;
    private MeshRenderer _meshRenderer;
    private Vector3 _respawnPosition;
    private Quaternion _respawnRotation;
    private bool _isShaking;

    private void Start()
    {
        _mainCollider = GetComponent<BoxCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();

        _triggerCollider = gameObject.AddComponent<BoxCollider>();
        _triggerCollider.size = new Vector3(1f, 2f, 1f);
        _triggerCollider.isTrigger = true;

        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;

        if (respawn)
        {
            _respawnPosition = transform.position;
            _respawnRotation = transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isShaking = true;
            StartCoroutine(ShakeEffect());
            StartCoroutine(Fall());
            StartCoroutine(DestroyOrHide());
            if (respawn)
            {
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeBeforeFall);
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
    }

    private IEnumerator ShakeEffect()
    {
        while (_isShaking)
        {
            _meshRenderer.material.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            _meshRenderer.material.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator DestroyOrHide()
    {
        yield return new WaitForSeconds(timeBeforeFall + timeBeforeDestroy);
        if (respawn)
        {
            _meshRenderer.enabled = false;
            _triggerCollider.enabled = false;
            _mainCollider.enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(timeBeforeFall + timeBeforeDestroy + timeToRespawn);
        _isShaking = false;
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        transform.position = _respawnPosition;
        transform.rotation = _respawnRotation;
        _meshRenderer.enabled = true;
        _triggerCollider.enabled = true;
        _mainCollider.enabled = true;
    }
}
