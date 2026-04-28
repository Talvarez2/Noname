using UnityEngine;

/// <summary>
/// Deals damage to players on contact with a spike hazard.
/// Configures its own collider on start.
/// </summary>
public class SpikeDamage : MonoBehaviour
{
    public int damage = 10;

    private void Start()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.size = Vector3.one;
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthAndDamage>().InflictDamage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthAndDamage>().InflictDamage(damage);
        }
    }
}
