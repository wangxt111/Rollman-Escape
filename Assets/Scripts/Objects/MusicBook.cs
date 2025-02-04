using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicBook : MonoBehaviour
{
    Vector3 CameraPositionAfterClick = new Vector3(8.5f, 0, 2.6f);
    public bool isfinished = false;
    Renderer objectrenderer;
    public GameObject targetobject;
    void Start()
    {
        objectrenderer = GetComponent<Renderer>();
        if(!isfinished){
            objectrenderer.enabled = false;
        }
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
                if(isfinished){
                    Utils.MoveCamera(CameraPositionAfterClick,false);
                }else if(info.currentobject == targetobject){
                    objectrenderer.enabled = true;
                    isfinished = true;
                    Utils.ClearTableButton(info.currentindex);
                }
            }
        }
    }
}