using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
// 放大的保险箱场景之间的切换
public class Safebox_perspective_open : MonoBehaviour
{
    public int scene = 1;
    public Sprite newSprite;
    void Start()
    {
        return;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ( ( scene == 1 && info.finishpassword1 == true ) || ( scene == 2 && info.finishpassword2 == true )))
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
                if (scene == 1)
                {
                    if (info.safe_box1 == 0) SwitchSprite();
                    if (info.safe_box1 == 1) Utils.ResetCamera();
                    if (info.safe_box1 != 2) ++info.safe_box1;
                }
                if (scene == 2)
                {
                    if (info.safe_box2 == 0) SwitchSprite();
                    if (info.safe_box2 == 1) Utils.ResetCamera();
                    if (info.safe_box2 != 2) ++info.safe_box2;
                }
            }
        }
    }

    public void SwitchSprite()
    {
        StartCoroutine(SwitchAndRestoreSprite());
    }

    IEnumerator SwitchAndRestoreSprite()
    {
        yield return new WaitForSeconds(0.2f);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
    }
}
