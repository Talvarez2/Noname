using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDamage : MonoBehaviour
{

    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthAndDamage>().InflictDamage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthAndDamage>().InflictDamage(damage);
        }
    }
}
