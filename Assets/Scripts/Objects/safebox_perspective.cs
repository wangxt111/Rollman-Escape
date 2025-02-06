using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// 切换到放大的保险箱场景
public class Safebox_perspective_close : MonoBehaviour
{
    Vector3 CameraPositionAfterClick = new Vector3(0, 0, 28);
    void Start()
    {
        return;
    }
    void Update()
    {
        if( info.safe_box == 0 ) CameraPositionAfterClick = new Vector3(0, 0, 28);
        if( info.safe_box == 1 ) CameraPositionAfterClick = new Vector3(0, 0, 38);
        if( info.safe_box == 2 ) CameraPositionAfterClick = new Vector3(0, 0, 48);
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
                Utils.MoveCamera(CameraPositionAfterClick,true);
            }
        }
    }
}