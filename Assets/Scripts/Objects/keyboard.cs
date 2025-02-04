using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class keyboard : MonoBehaviour
{
    public int KeyboardID;
    public bool isfinished;
    Renderer keyboardrenderer;
    public Sprite newSprite; // 在Inspector中赋值为要切换的新图片
    public float switchDuration = 0.5f; // 切换持续时间

    private Sprite originalSprite; // 用于存储原始Sprite
    private bool isSwitching = false; // 标记是否正在切换Sprite
    void Start()
    {
        originalSprite = GetComponent<SpriteRenderer>().sprite;
        keyboardrenderer = GetComponent<Renderer>();
        if(!isfinished){
            keyboardrenderer.enabled = false;
        }
        return;
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
        // 通过摄像机将屏幕坐标转换为射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // 射线检测，增加距离参数以确保足够的检测范围
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // 如果射线击中了当前物体
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                if(isfinished){
                    Debug.Log("击中了键盘"+KeyboardID);
                    SwitchSprite();
                }
            }
        }
        else
        {
            // 可选：调试信息，帮助理解为什么没有击中任何对象
            Debug.Log("没有击中任何对象");
        }
    }
    // 调用此方法来开始切换Sprite的过程
    public void SwitchSprite()
    {
        if (!isSwitching)
        {
            StartCoroutine(SwitchAndRestoreSprite());
        }
    }

    IEnumerator SwitchAndRestoreSprite()
    {
        isSwitching = true; // 标记正在切换

        // 切换Sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;

        // 等待1秒
        yield return new WaitForSeconds(switchDuration);

        // 恢复原始Sprite
        spriteRenderer.sprite = originalSprite;

        isSwitching = false; // 标记切换结束
    }
}