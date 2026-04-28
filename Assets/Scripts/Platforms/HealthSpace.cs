using UnityEngine;

/// <summary>
/// Area that heals players while they remain inside the trigger zone.
/// Uses negative damage via InflictDamage to restore health.
/// </summary>
public class HealthSpace : MonoBehaviour
{
    public int health = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthAndDamage>().InflictDamage(-health);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthAndDamage>().InflictDamage(-health);
        }
    }
}
