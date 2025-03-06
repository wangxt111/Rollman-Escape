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
        // 检测鼠标左键是否被按下
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
        if(info.switchingtolevel2 && transform.position.y < 0f)transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void HandleMouseClick()
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
                return;
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