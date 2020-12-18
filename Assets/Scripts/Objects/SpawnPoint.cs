using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Color blue = Color.blue;
    private Color red = Color.red;
    private Color green = Color.green;
    private GameObject Light;
    private Light _light;
    private SpriteRenderer spriteRed;
    private SpriteRenderer spriteGreen;
    private SpriteRenderer spriteBlue;


    void Start()
    {
        _light = gameObject.GetComponentInChildren<Light>();

        spriteRed = this.transform.Find("SpriteRed").GetComponent<SpriteRenderer>();
        spriteGreen = this.transform.Find("SpriteGreen").GetComponent<SpriteRenderer>();
        spriteBlue = this.transform.Find("SpriteBlue").GetComponent<SpriteRenderer>();

        spriteRed.enabled = false;
        spriteGreen.enabled = false;
        spriteBlue.enabled = true;
    }

    public void ChangeColor(string color)
    {

        if (color == "red")
        {
            _light.color = red;
            spriteRed.enabled = true;
            spriteGreen.enabled = false;
            spriteBlue.enabled = false;
        }
        else if (color == "blue")
        {
            _light.color = blue;
            spriteRed.enabled = false;
            spriteGreen.enabled = false;
            spriteBlue.enabled = true;
        }
        else if (color == "green")
        {
            _light.color = green;
            spriteRed.enabled = false;
            spriteGreen.enabled = true;
            spriteBlue.enabled = false;
        }
    }

    public string GetColor()
    {
        Color actualColor = _light.color;

        if (actualColor.Equals(red))
        {
            return "red";
        }
        if (actualColor.Equals(blue))
        {
            return "blue";
        }
        if (actualColor.Equals(green))
        {
            return "green";
        }
        return null;
    }

    public void activateAudio()
    {
        if (Time.time > 0.5f)
        {
            transform.GetComponent<SoundEffect>().playEnabled = true;
        }
    }

}
