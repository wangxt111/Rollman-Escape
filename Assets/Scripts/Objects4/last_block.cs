using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Last_Block : MonoBehaviour
{
    public Sprite[] sprites;
    void Start()
    {
        Renderer Renderer = GetComponent<Renderer>();
        Renderer.enabled = false;
        return;
    }
    void Update()
    {
        if( info.finish_level4 == true )
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites[info.block_type];
            Renderer Renderer = GetComponent<Renderer>();
            Renderer.enabled = true;
        }
    }
}