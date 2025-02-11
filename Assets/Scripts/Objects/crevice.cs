using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crevice : MonoBehaviour
{
    public Sprite[] newSprites;

    void Start()
    {
    }

    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (info.horizontal_bar == 2) spriteRenderer.sprite = newSprites[0];
        if (info.horizontal_bar == 3) spriteRenderer.sprite = newSprites[1];
    }
}