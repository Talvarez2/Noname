using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public int initialLife = 100;
    public int life;
    public bool invincible;
    public float invincibleTime = 1f;
    public float stopTime = 0.2f;  // time the player stops after recieving damage
    public HealtBar healtBar;


    void Start()
    {
        RestartLife();
    }

    public void RestartLife()
    {
        life = initialLife;
        healtBar.SetMaxHealth(initialLife);
    }

    public void InflictDamage(int damage)
    {
        if (!invincible && life > 0)
        {
            life -= damage;
            healtBar.SetHealth(life);
            StartCoroutine(Invunerability());
            StartCoroutine(DecreaseSpeed());
            if (life <= 0)
            {
                GetComponent<HandleDeath>().Die();
            }
        }
    }

    IEnumerator Invunerability()
    {
        // can't recieve damage more than once in 'invincibleTime' seconds
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }

    IEnumerator DecreaseSpeed()
    {
        var currentSpeed = GetComponent<PlayerController>().playerSpeed;
        Debug.Log(currentSpeed);
        GetComponent<PlayerController>().playerSpeed = 0;
        yield return new WaitForSeconds(stopTime);
        GetComponent<PlayerController>().playerSpeed = currentSpeed;
    }
}
