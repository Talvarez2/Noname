using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI health bar that displays player health using a Unity UI Slider.
/// </summary>
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    /// <summary>
    /// Sets the maximum health value and fills the bar completely.
    /// </summary>
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    /// <summary>
    /// Updates the health bar to reflect the current health value.
    /// </summary>
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
