using UnityEngine;

public class ChangeSprite : MonoBehaviour {
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public void NewSprite(int spriteId) {
        spriteRenderer.sprite = sprites[spriteId];
    }
}
