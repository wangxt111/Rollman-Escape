using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Water_level2 : MonoBehaviour
{
    public Sprite[] anime;
    public float speed = 1f;
    public GameObject[] objectdownwithwater;
    void Start()
    {
        WaterAppear();
        return;
    }
    void Update()
    {
        if(!info.switchingtolevel2 && transform.localPosition.y > info.waterhight){
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            foreach (GameObject obj in objectdownwithwater)
            {
                obj.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
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