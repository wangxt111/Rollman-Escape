using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public Sprite image;
    void Start()
    {
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
                GameObject freebutton = GameObject.Find("MainController").GetComponent<buttonmanager>().getfirstfreebutton();
                if (freebutton != null)
                {
                    freebutton.GetComponent<tablebutton>().changeimage(freebutton, image);
                    freebutton.GetComponent<tablebutton>().changestore(freebutton, this.gameObject);
                    if( this.gameObject.name == "ink" ) info.ink = true;
                    if( this.gameObject.name == "tomato" ) info.tomato = true;
                    if( this.gameObject.name == "manual_close" ) info.manual_table = 1;
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}