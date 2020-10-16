using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int damage = 10;
    BoxCollider m_Collider;

    private void Start() 
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<BoxCollider>();
        m_Collider.size = new Vector3(1, 5, 1);
        m_Collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthAndDamage>().InflictDamage(damage);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthAndDamage>().InflictDamage(damage);
        }
    }
}