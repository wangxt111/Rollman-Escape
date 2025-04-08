using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Plane : MonoBehaviour
{
    void Start()
    {
        return;
    }
    void Update()
    {
        if (info.piece7_key && info.piece7_plane)
        {
            info.piece[7] = true;
            ++ info.finish_piece_num;
            Utils.ResetCamera();
            this.gameObject.SetActive(false);
        }
        Collider Collider = GetComponent<Collider>();
        Collider.enabled = info.drawer[0];
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
                Renderer Renderer = GetComponent<Renderer>();
                Renderer.enabled = false;
                Collider Collider = GetComponent<Collider>();
                Collider.enabled = false;
                info.piece7_plane = true;
            }
        }
    }
}