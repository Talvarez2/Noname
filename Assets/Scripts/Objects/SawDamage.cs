using UnityEngine;

/// <summary>
/// Deals damage to players on contact with a saw hazard.
/// </summary>
public class SawDamage : MonoBehaviour
{
    public int damage;

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
