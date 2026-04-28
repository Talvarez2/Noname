using UnityEngine;

/// <summary>
/// Area that deals damage to players while they remain inside the trigger zone.
/// </summary>
public class DamageSpace : MonoBehaviour
{
    public int damage = 10;

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
