using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public int initialLife = 100;
    private int life;
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

    public void SetLife(int playerLife) {
        life = playerLife;
        healtBar.SetHealth(playerLife);
    }

    public int GetActualLife() {
        return life;
    }

    public void InflictDamage(int damage)
    {
        if (!invincible && life > 0 && damage > 0)
        {
            life -= damage;
            healtBar.SetHealth(life);
            StartCoroutine(Invunerability());
            StartCoroutine(StopMovement());
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

    IEnumerator StopMovement()
    {
        GameObject mover = transform.Find("Mover").gameObject;
        var currentSpeed = mover.GetComponent<InputMover>().actualPlayerSpeed;
        mover.GetComponent<InputMover>().actualPlayerSpeed = 0;
        yield return new WaitForSeconds(stopTime);
        mover.GetComponent<InputMover>().actualPlayerSpeed = currentSpeed;
    }
}
