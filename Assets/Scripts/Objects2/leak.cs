using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Leak : MonoBehaviour
{
    SpriteRenderer objectrenderer;
    int count = 0; //被砸的次数
    public GameObject[] targetobject;
    public Sprite[] Image;
    void Start()
    {
        objectrenderer = GetComponent<SpriteRenderer>();
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
                if(targetobject.Contains(info.currentobject)){
                    Utils.ClearTableButton(info.currentindex);
                    count ++;
                    if(count == 1){
                        objectrenderer.enabled = true; // 显示物体
                        info.waterhight -= 0.33f;
                    }else if(count == 2){
                        objectrenderer.sprite = Image[0];
                        info.waterhight -= 0.33f;
                    }else if(count == 3){
                        objectrenderer.sprite = Image[1];
                    }
                }
            }
        }
    }
}