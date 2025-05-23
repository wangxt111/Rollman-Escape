using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Drain : MonoBehaviour
{
    bool isout = false;
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

    private void HandleMouseClick()
    {
        // 通过摄像机将屏幕坐标转换为射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // 射线检测，增加距离参数以确保足够的检测范围
        int layerMask = ~LayerMask.GetMask("UI"); // 忽略UI层
        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            // 如果射线击中了当前物体
            if (!isout && hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                this.gameObject.transform.localPosition = new Vector3(1,0,0);
                info.waterhight -= 0.6f;
                isout = true;
            }
        }
    }
}