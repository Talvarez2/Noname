using System.Collections;
using UnityEngine;

/// <summary>
/// Manages player health, damage, invincibility frames, and the red flash damage effect.
/// </summary>
public class HealthAndDamage : MonoBehaviour
{
    public int initialLife = 100;
    public bool invincible;
    public float invincibleTime = 1f;
    public float stopTime = 0.2f;
    public HealthBar healthBar;
    public Color originalColor = new Color(1f, 1f, 1f, 1f);

    private int _life;
    private SpriteRenderer _spriteRenderer;
    private bool _isFlashingRed;

    private void Start()
    {
        RestartLife();
        _spriteRenderer = GetComponentInParent<PlayerData>().spriteRenderer;
        _spriteRenderer.material.color = originalColor;
    }

    /// <summary>
    /// Resets the player's life to the initial value and updates the health bar.
    /// </summary>
    public void RestartLife()
    {
        _life = initialLife;
        healthBar.SetMaxHealth(initialLife);
    }

    /// <summary>
    /// Sets the player's life to a specific value and updates the health bar.
    /// </summary>
    public void SetLife(int playerLife)
    {
        _life = playerLife;
        healthBar.SetHealth(playerLife);
    }

    /// <summary>
    /// Returns the player's current life.
    /// </summary>
    public int GetActualLife()
    {
        return _life;
    }

    /// <summary>
    /// Inflicts damage on the player, triggering invincibility frames and visual feedback.
    /// </summary>
    public void InflictDamage(int damage)
    {
        StartCoroutine(FlashRedOnDamage());
        if (!invincible && _life > 0)
        {
            _life -= damage;
            healthBar.SetHealth(_life);
            PlayDamageSound();
            StartCoroutine(ApplyInvincibility());
            StartCoroutine(BrieflyStopMovement());
            if (_life <= 0)
            {
                GetComponent<HandleDeath>().Die();
            }
        }
    }

    private void PlayDamageSound()
    {
        AudioSource damageSound = GetComponentInParent<PlayerData>().damageSound;
        if (!damageSound.isPlaying)
        {
            damageSound.Play();
        }
    }

    private IEnumerator ApplyInvincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }

    private IEnumerator FlashRedOnDamage()
    {
        if (!_isFlashingRed)
        {
            _isFlashingRed = true;
            _spriteRenderer.material.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            _spriteRenderer.material.color = originalColor;
            yield return new WaitForSeconds(0.2f);
            _isFlashingRed = false;
        }
    }

    private IEnumerator BrieflyStopMovement()
    {
        InputMover inputMover = transform.Find("Mover").GetComponent<InputMover>();
        float currentSpeed = inputMover.playerSpeed;
        inputMover.playerSpeed = 0f;
        yield return new WaitForSeconds(stopTime);
        inputMover.playerSpeed = currentSpeed;
    }
}
