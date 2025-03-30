using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Manual_Object  : MonoBehaviour
{
    Vector3 CameraPositionAfterClick = new Vector3(0, 64, 0);
    public GameObject targetobject;
    public bool isfinished;
    Renderer objectrenderer;
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
                if(!isfinished && targetobject && info.currentobject == targetobject)
                {
                    objectrenderer.enabled = true;
                    isfinished = true;
                    Utils.ClearTableButton(info.currentindex);
                    info.manual_object_num ++;
                    if (info.manual_object_num == 3)
                    {
                        StartCoroutine(MoveCameraAfterDelay());
                    }
                }
            }
        }
    }

    private IEnumerator MoveCameraAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Utils.MoveCamera(CameraPositionAfterClick, true, true);
    }
}