using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Piano_perspective : MonoBehaviour
{
    Vector3 CameraPositionAfterClick = new Vector3(0, 0, 80);
    public GameObject bird;
    public Sprite[] anime;
    public Sprite[] closeanime;
    public Sprite finalbird;
    void Start()
    {
        return;
    }
    void Update()
    {
        // 检测鼠标左键是否被按下
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    private async void HandleMouseClick()
    {
        // 通过摄像机将屏幕坐标转换为射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // 射线检测，增加距离参数以确保足够的检测范围
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // 如果射线击中了当前物体
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                // 异步等待0.1秒（100毫秒）,防止误触发keyboard
                await Task.Delay(100);
                Utils.MoveCamera(CameraPositionAfterClick,true);
            }
        }
    }
    public void BirdAppear(){
        StartCoroutine(WaitAndSwitchSpritesSequentially(anime));
    }
    public IEnumerator WaitAndSwitchSpritesSequentially(Sprite[] sprites)
    {
        SpriteRenderer spriteRenderer = bird.GetComponent<SpriteRenderer>();
        bird.GetComponent<Renderer>().enabled = true;
        foreach (Sprite spr in sprites)
        {
            spriteRenderer.sprite = spr;
            yield return new WaitForSeconds(0.167f);
        }
        spriteRenderer.sprite = finalbird;
        GameObject.Find("Award").GetComponent<Renderer>().enabled = true;
        GameObject.Find("Award").GetComponent<BoxCollider>().enabled = true;
    }

    public void PianoClose(){
        StartCoroutine(WaitAndSwitchSpritesSequentiallyforPianoClose(closeanime));

    }
    public IEnumerator WaitAndSwitchSpritesSequentiallyforPianoClose(Sprite[] sprites)
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