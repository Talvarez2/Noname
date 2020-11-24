using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSigns : MonoBehaviour
{
    public Sprite SkullPanel;
    public Sprite HeartPanel;
    public bool Damage;
    public bool Change;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSprite();
    }

    void SetSprite()
    {
        if (Damage){
            spriteRenderer.sprite = SkullPanel;
        } else {
            spriteRenderer.sprite = HeartPanel;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (Change)
        {
            Change = false;
            Damage = !Damage;
            SetSprite();
        }
    }

}
