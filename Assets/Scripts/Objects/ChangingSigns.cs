using UnityEngine;

/// <summary>
/// Toggleable sign that switches between skull and heart sprites on trigger contact.
/// </summary>
public class ChangingSigns : MonoBehaviour
{
    public Sprite SkullPanel;
    public Sprite HeartPanel;
    public bool Damage;
    public bool Change;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetSprite();
    }

    private void SetSprite()
    {
        _spriteRenderer.sprite = Damage ? SkullPanel : HeartPanel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Change)
        {
            Change = false;
            Damage = !Damage;
            SetSprite();
        }
    }
}
