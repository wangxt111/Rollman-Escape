using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Sprite[] anime;
    public float speed = 1f;
    void Start()
    {
        return;
    }
    void Update()
    {
        if(info.switchingtolevel2 && transform.position.y < 0f)transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    public void WaterAppear(){
        StartCoroutine(WaitAndSwitchSpritesSequentially(anime));

    }
    public IEnumerator WaitAndSwitchSpritesSequentially(Sprite[] sprites)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Renderer>().enabled = true;
        while (true){
            foreach (Sprite spr in sprites)
            {
                spriteRenderer.sprite = spr;
                yield return new WaitForSeconds(0.167f);
            }
        }
    }
}