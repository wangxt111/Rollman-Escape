using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Window : MonoBehaviour
{
    public Sprite[] anime;
    void Start()
    {
        return;
    }
    void Update()
    {
        return;
    }
    public void WindowClose(){
        StartCoroutine(WaitAndSwitchSpritesSequentially(anime));

    }
    public IEnumerator WaitAndSwitchSpritesSequentially(Sprite[] sprites)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Renderer>().enabled = true;
        foreach (Sprite spr in sprites)
        {
            spriteRenderer.sprite = spr;
            yield return new WaitForSeconds(0.167f);
        }
    }
}