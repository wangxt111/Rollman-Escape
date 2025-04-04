using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// 切换到放大的保险箱场景
public class Cabinet : MonoBehaviour
{
    private Renderer[] childRenderers;
    private Collider[] childColliders;
    void Start()
    {
        childRenderers = GetComponentsInChildren<Renderer>(true);
        childColliders = GetComponentsInChildren<Collider>(true);
        foreach (Renderer renderer in childRenderers)
        {
            renderer.enabled = false;
        }
        foreach (Collider collider in childColliders)
        {
            if (collider.gameObject != this.gameObject)
            {
                collider.enabled = false;
            }
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
            if (hit.collider != null && hit.collider.gameObject == this.gameObject )
            {
                Collider collider = GetComponent<Collider>();
                collider.enabled = false;
                childRenderers = GetComponentsInChildren<Renderer>(true);
                foreach (Renderer renderer in childRenderers)
                {
                    renderer.enabled = true;
                }
                foreach (Collider colliderer in childColliders)
                {
                    if (colliderer.gameObject != this.gameObject)
                    {
                        colliderer.enabled = true;
                    }
                }
            }
        }
    }
}