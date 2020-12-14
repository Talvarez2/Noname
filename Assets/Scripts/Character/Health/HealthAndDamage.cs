using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public int initialLife = 100;
    private int life;
    public bool invincible;
    public float invincibleTime = 1f;
    public float damageColorTime = 5;
    public float stopTime = 0.2f;  // time the player stops after recieving damage
    public HealtBar healtBar;

    public Color originalColor = new Color(1, 1, 1, 0_01f);
    private SpriteRenderer spriteRenderer;
    private bool isRed = false;


    void Start()
    {
        RestartLife();
        spriteRenderer = GetComponentInParent<PlayerData>().spriteRenderer;
        spriteRenderer.material.color = originalColor;
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
        StartCoroutine(ColorRedDamage());
        if (!invincible && life > 0)
        {
            life -= damage;
            healtBar.SetHealth(life);
            PlayDamageSound();
            StartCoroutine(Invunerability());
            StartCoroutine(StopMovement());
            if (life <= 0)
            {
                GetComponent<HandleDeath>().Die();
            }
        }
    }

    void PlayDamageSound()
    {
        if (!GetComponentInParent<PlayerData>().damageSound.isPlaying)
        {
            GetComponentInParent<PlayerData>().damageSound.Play();
        }
    }

    IEnumerator Invunerability()
    {
        // can't recieve damage more than once in 'invincibleTime' seconds
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }

    IEnumerator ColorRedDamage()
    {
        // Flashes red once
        if(!isRed){
            isRed = true;
            spriteRenderer.material.color = Color.red;
            yield return new WaitForSeconds(0.2F);
            spriteRenderer.material.color = originalColor;
            yield return new WaitForSeconds(0.2F);
            isRed = false;
        }
    }

    IEnumerator StopMovement()
    {
        GameObject mover = transform.Find("Mover").gameObject;
        var currentSpeed = mover.GetComponent<InputMover>().playerSpeed;
        mover.GetComponent<InputMover>().playerSpeed = 0;
        yield return new WaitForSeconds(stopTime);
        mover.GetComponent<InputMover>().playerSpeed = currentSpeed;
    }
}
