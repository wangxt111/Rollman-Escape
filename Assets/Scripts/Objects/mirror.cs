using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Sprite on_bar;
    public Sprite[] newSprites1;
    public Sprite[] newSprites2;
    private bool isSwitching = false; // 标记是否正在切换Sprite

    void Start()
    {
    }

    void Update()
    {
        if (info.is_switching == false) return;
        if (info.horizontal_bar == 1)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = on_bar;
        }
        else if (info.horizontal_bar == 2)
        {
            StartCoroutine(WaitAndSwitchSpritesSequentially(newSprites1));
        }
        else if (info.horizontal_bar == 3)
        {
            StartCoroutine(WaitAndSwitchSpritesSequentially(newSprites2));
            info.manual = 1;
        }

        info.is_switching = false;
    }
    private IEnumerator WaitAndSwitchSpritesSequentially(Sprite[] sprites)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        foreach (Sprite spr in sprites)
        {
            spriteRenderer.sprite = spr;
            yield return new WaitForSeconds(0.167f);
        }
    }
}