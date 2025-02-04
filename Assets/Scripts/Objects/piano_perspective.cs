using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class piano_perspective : MonoBehaviour
{
    Vector3 CameraPositionAfterClick = new Vector3(0, 0, 80);
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // 如果射线击中了当前物体
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                Debug.Log("击中钢琴");
                Utils.MoveCamera(CameraPositionAfterClick);
            }
            else
            {
                Debug.Log("射线击中的对象：" + hit.collider?.name);
            }
        }
        else
        {
            // 可选：调试信息，帮助理解为什么没有击中任何对象
            Debug.Log("没有击中任何对象");
        }
    }
}