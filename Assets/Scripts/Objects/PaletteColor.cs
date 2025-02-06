using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PaletteColor  : MonoBehaviour
{
    public Color color;
    public Sprite newSprite;
    public GameObject targetobject;
    public bool isfinished;
    Renderer objectrenderer;
    GameObject brush;
    void Start()
    {
        objectrenderer = GetComponent<Renderer>();
        if(!isfinished){
            objectrenderer.enabled = false;
        }
        brush = GameObject.FindWithTag("Brush");
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
                if(!isfinished && targetobject && info.currentobject == targetobject){
                    objectrenderer.enabled = true;
                    isfinished = true;
                    Utils.ClearTableButton(info.currentindex);
                }else if(isfinished && info.currentobject == brush){
                    info.brush_color = color;
                    Utils.ChangeTableButton(info.currentindex, newSprite);
                }
            }
        }
    }
}