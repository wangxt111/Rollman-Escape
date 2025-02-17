using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Carpet : MonoBehaviour
{
    public Sprite carpet1;
    public Sprite carpet2;
    public Sprite carpet3;
    public GameObject keyboard;
    bool hidekeyboard = true;
    int state = 1; //1：有琴键 2:无琴键 3：被翻开
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        return;
    }
    void Update()
    {
        if(info.currentobject != null)Debug.Log(info.currentobject.name);
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
                if(info.carpethidekeyboard){
                    if (state == 1){
                        spriteRenderer.sprite = carpet3;
                        keyboard.GetComponent<BoxCollider>().enabled = true;
                        state = 3;
                    }else if (state == 3){
                        spriteRenderer.sprite = carpet1;
                        keyboard.GetComponent<BoxCollider>().enabled = false;
                        state = 1;
                    }
                }else{
                    if(state == 3){
                        if(hidekeyboard){
                            hidekeyboard = false;
                        }else{
                            spriteRenderer.sprite = carpet2;
                            state = 2;
                        }
                    }else if(state == 2){
                        spriteRenderer.sprite = carpet3;
                        state = 3;
                    }
                }
            }
        }
    }
    
}