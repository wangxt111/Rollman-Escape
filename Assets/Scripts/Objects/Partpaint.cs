using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TerrainTools;

public class PartOfPaint : MonoBehaviour
{
    public Color32 TargetColor;
    SpriteRenderer sp;
    public int number; //碎片编号
    public Sprite finishedpaint; //完成上色后的图片
    public GameObject[] parts; //碎片数组
    GameObject brush;
    void Start()
    {
        brush = GameObject.FindWithTag("Brush");
        sp = GetComponent<SpriteRenderer>();
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
                Debug.Log("Painted!");
                if(info.currentobject == brush){
                    if(info.brush_color != Color.clear){
                        ChangeColorTo(info.brush_color);
                        if((Color)info.brush_color == TargetColor){
                            Debug.Log("Painted correctly!");
                            info.correctcolor[number] = true;
                            if(CheckColor()){
                                SpriteRenderer paintrender = GameObject.FindWithTag("Paint").GetComponent<SpriteRenderer>();
                                paintrender.sprite =  finishedpaint;
                                info.finishpaint = true;
                                foreach (GameObject part in parts){
                                    part.SetActive(false);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    void ChangeColorTo(Color newcolor){
        sp.color = newcolor;
    }
    bool CheckColor(){
        foreach(bool b in info.correctcolor){
            if(b == false){
                return false;
            }
        }
        return true;
    }
}