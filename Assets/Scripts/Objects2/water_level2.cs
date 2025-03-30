using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Water_level2 : MonoBehaviour
{
    public Sprite[] anime;
    public Sprite[] darkwater;
    public float speed = 1f;
    public GameObject[] objectdownwithwater;
    public GameObject flashlight;
    void Start()
    {
        WaterAppear();
        return;
    }
    void Update()
    {
        if( info.waterlevel2 == false )
        {
            Renderer Renderer = GetComponent<Renderer>();
            Renderer.enabled = false;
            return;
        }
        else
        {
            Renderer Renderer = GetComponent<Renderer>();
            Renderer.enabled = true;
        }
        if(!info.switchingtolevel2 && transform.localPosition.y > info.waterhight){
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            foreach (GameObject obj in objectdownwithwater)
            {
                obj.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }
    public void WaterAppear(){
        StartCoroutine(WaitAndSwitchSpritesSequentially(anime,darkwater));

    }
    public IEnumerator WaitAndSwitchSpritesSequentially(Sprite[] sprites, Sprite[] other)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Renderer>().enabled = true;
        while (true){
            for(int i = 0; i < sprites.Length; i++)
            {
                if(info.getflashlight){
                    spriteRenderer.sprite = sprites[i];
                }else{
                    spriteRenderer.sprite = other[i];
                }
                yield return new WaitForSeconds(0.167f);
            }
        }
    }
}