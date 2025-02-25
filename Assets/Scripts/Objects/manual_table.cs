using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manual_Table : MonoBehaviour
{
    Vector3 CameraPositionAfterClick = new Vector3(0, 48, 0);
    public int type = 0; // 0: 小场景 1: 放大场景
    public GameObject targetobject;
    private Renderer manual_renderer;
    private Collider manual_collider;
    void Start()
    {
        manual_renderer = GetComponent<Renderer>();
        manual_renderer.enabled = false;
        manual_collider = GetComponent<Collider>();
        manual_collider.enabled = false;
        return;
    }
    void Update()
    {
        if( info.manual_table == 1 )
        {
            manual_collider.enabled = true;
        }
        if( info.manual_table == 2 )
        {
            if( type == 0 ) manual_collider.enabled = false;
            manual_renderer.enabled = true;
        }
        if ( Input.GetMouseButtonDown(0) )
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
                if(info.currentobject == targetobject){
                    manual_renderer.enabled = true;
                    if( info.manual_table == 1 )
                    {
                        info.manual_table = 2;
                        Utils.ClearTableButton(info.currentindex);
                    }
                }
                if( info.manual_table == 2 && type == 1 )
                {
                    Utils.MoveCamera(CameraPositionAfterClick,true,true);
                }
            }
        }
    }
}