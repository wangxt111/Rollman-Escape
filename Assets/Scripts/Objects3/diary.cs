using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public Sprite newSprites; // 要切换的新图片数组
    private bool isSwitching = false; // 标记是否正在切换Sprite
    public GameObject targetobject;

    void Start()
    {
    }

    void Update()
    {
        // 检测鼠标左键是否被按下
        if (!isSwitching && Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null && hit.collider.gameObject == this.gameObject && info.currentobject == targetobject)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = newSprites;
                GetComponent<Collider>().enabled = false;
                info.card = 1;
            }
        }
    }
}