using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpace : MonoBehaviour
{
    public int health = 5;
    BoxCollider m_Collider;

    private void Start() 
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthAndDamage>().InflictDamage(-health);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthAndDamage>().InflictDamage(-health);
        }
    }
}
