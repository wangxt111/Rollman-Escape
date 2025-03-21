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
        if (info.horizontal_bar == 2)
        {
            StartCoroutine(WaitAndSwitchSprites(newSprites[0]));
        }
        if (info.horizontal_bar == 3)
        {
            StartCoroutine(WaitAndSwitchSprites(newSprites[1]));
        }
    }
    private IEnumerator WaitAndSwitchSprites(Sprite sprite)
    {
        yield return new WaitForSeconds(0.9f);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}