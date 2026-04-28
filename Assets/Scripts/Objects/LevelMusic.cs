using UnityEngine;

/// <summary>
/// Sets the background music volume from player preferences on level start.
/// </summary>
public class LevelMusic : MonoBehaviour
{
    private void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music Volume", 1f);
    }
}
