using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public int scene_num;
    
    // Start is called before the first frame update
    // 开始方法
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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
                    Debug.Log("id" + freebutton.GetComponent<tablebutton>().buttonID);
                    freebutton.GetComponent<tablebutton>().changetext(freebutton, this.gameObject.name);
                    freebutton.GetComponent<tablebutton>().changestore(freebutton, this.gameObject);
                    this.gameObject.SetActive(false);
                }
            }
            else
            {
                // 可选：调试信息，帮助理解为什么没有击中预期的对象
                Debug.Log("射线击中的对象：" + hit.collider?.name);
            }
        }
        else
        {
            // 可选：调试信息，帮助理解为什么没有击中任何对象
            Debug.Log("没有击中任何对象");
        }
    }

    // private void OnMouseDown()
    // {
    //     GameObject freebutton = GameObject.Find("MainController").GetComponent<buttonmanager>().getfirstfreebutton();
    //     if (freebutton != null){
    //         Debug.Log("id"+freebutton.GetComponent<tablebutton>().buttonID);
    //         freebutton.GetComponent<tablebutton>().changetext(freebutton, this.gameObject.name);
    //         freebutton.GetComponent<tablebutton>().changestore(freebutton, this.gameObject);
    //         this.gameObject.SetActive(false);
    //     }
    // }
    // private void OnMouseEnter()
    // {
    //     // 当鼠标进入物体的碰撞器时调用
    //     Debug.Log("鼠标进入物体：" + this.gameObject.name);
    // }

    // private void OnMouseExit()
    // {
    //     // 当鼠标离开物体的碰撞器时调用
    //     Debug.Log("鼠标离开物体：" + this.gameObject.name);
    // }
}