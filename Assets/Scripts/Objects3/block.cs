using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Sprite[] sprites;
    private int currentSpriteIndex;
    private SpriteRenderer spriteRenderer;

    void Start(){
        currentSpriteIndex = Random.Range(0, sprites.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }

    void Update(){
        return;
    }

    public void SwitchSprite(){
        currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }
}
