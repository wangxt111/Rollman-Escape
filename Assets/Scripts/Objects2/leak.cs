using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Leak : MonoBehaviour
{
    SpriteRenderer objectrenderer;
    int count = 0; //被砸的次数
    public GameObject[] targetobject;
    public Sprite[] Image;
    public GameObject Hammer;
    private bool almostbreak = false;
    public GameObject window1;
    public GameObject window2;
    public GameObject breakwindow;
    public GameObject water;
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
        int layerMask = ~LayerMask.GetMask("UI"); // 忽略UI层
        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            // 如果射线击中了当前物体
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                if(water.transform.localPosition.y < -8.5f){
                    GameObject camera = GameObject.Find("Main Camera");
                    info.level = 3;
                    camera.transform.position = Constants.Constants.level_3_camera;
                }
                if(targetobject.Contains(info.currentobject)){
                    Utils.ClearTableButton(info.currentindex);
                    count ++;
                    if(count == 1){
                        objectrenderer.enabled = true; // 显示物体
                        info.waterhight -= 1f;
                    }else if(count == 2){
                        objectrenderer.sprite = Image[0];
                        info.waterhight -= 1f;
                    }
                }else if(info.currentobject == Hammer){
                    if(!almostbreak){
                        info.waterhight -= 0.6f;
                        almostbreak = true;
                        objectrenderer.sprite = Image[1];
                    }else{
                        window1.GetComponent<SpriteRenderer>().enabled = false;
                        window2.GetComponent<SpriteRenderer>().enabled = false;
                        objectrenderer.enabled = false;
                        breakwindow.GetComponent<SpriteRenderer>().enabled = true;
                        info.waterhight = -9f;
                    }
                }
            }
        }
    }
}