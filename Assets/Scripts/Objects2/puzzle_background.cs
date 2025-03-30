using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puzzle_Background : MonoBehaviour
{
    public Sprite Sprites_Green;
    public Sprite Sprites_Yellow;
    private bool isSwitching = false;

    void Start()
    {
    }

    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if( info.puzzle_num == 0 ) spriteRenderer.sprite = Sprites_Green;
        else spriteRenderer.sprite = Sprites_Yellow;
    }
}