using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Horizontal_bar : MonoBehaviour
{
    private bool isSwitching = false; // 标记是否正在切换Sprite

    void Start()
    {
    }

    void Update()
    {
        if (info.currentobject != null) Debug.Log(info.currentobject.name);
        
        // 检测鼠标左键是否被按下
        if (!isSwitching && Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                if (info.horizontal_bar != 3)
                {
                    ++ info.horizontal_bar ;
                    info.is_switching = true ;
                }
            }
        }
    }
}