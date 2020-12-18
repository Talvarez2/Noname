using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int playerNum;
    public SpriteRenderer spriteRenderer;
    public bool isOnIceFloor = false;
    public AudioSource jumpSound;
    public AudioSource damageSound;

    private void Update()
    {
        float gamevol = PlayerPrefs.GetFloat("Game Volume", 1);
        float gamevolold = PlayerPrefs.GetFloat("Game Volume old", 1);
        if (gamevol != gamevolold)
        {
            jumpSound.volume = gamevol;
            damageSound.volume = gamevol;
            PlayerPrefs.SetFloat("Game Volume old", gamevolold);
        }
    }
}
