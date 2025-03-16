using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Passwordkey : MonoBehaviour
{
    public int scene = 1;
    public int passwordkeyID;
    Renderer passwordkeyrenderer;
    public Sprite newSprite; // 在Inspector中赋值为要切换的新图片
    public float switchDuration = 0.5f; // 切换持续时间

    private Sprite originalSprite; // 用于存储原始Sprite
    private bool isSwitching = false; // 标记是否正在切换Sprite
    void Start()
    {
        originalSprite = GetComponent<SpriteRenderer>().sprite;
        passwordkeyrenderer = GetComponent<Renderer>();
        return;
    }
    void Update()
    {
        if(info.currentobject != null)Debug.Log(info.currentobject.name);
        // 检测鼠标左键是否被按下
        if (!isSwitching && Input.GetMouseButtonDown(0))
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
                SwitchSprite();
                if( ( scene == 1 && info.finishpassword1 == true ) || ( scene == 2 && info.finishpassword2 == true ) ) return;
                info.currentpassword.Add(passwordkeyID);
                if(CheckPassword()){
                    if( scene == 1 ) info.finishpassword1 = true;
                    if( scene == 2 ) info.finishpassword2 = true;
                    Debug.Log("finishpassword");
                    info.currentpassword.Clear();
                }
            }
        }
    }
    // 调用此方法来开始切换Sprite的过程
    public void SwitchSprite()
    {
        if (!isSwitching)
        {
            StartCoroutine(SwitchAndRestoreSprite());
        }
    }

    IEnumerator SwitchAndRestoreSprite()
    {
        isSwitching = true; // 标记正在切换

        // 切换Sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;

        // 等待1秒
        yield return new WaitForSeconds(switchDuration);

        // 恢复原始Sprite
        spriteRenderer.sprite = originalSprite;

        isSwitching = false; // 标记切换结束
    }
    bool CheckPassword(){
        int l = info.currentpassword.Count;
        int c = 0;
        if(scene == 1){
            c = info.targetpassword1.Count;
        }
        else if(scene == 2){
            c = info.targetpassword2.Count;
        }
        if(l>=c){
            for(int i=1;i<=c;i++){
                Debug.Log(info.currentpassword[l-i]);
                int target = 0;
                if(scene == 1){
                    target = info.targetpassword1[c-i];
                }
                else if(scene == 2){
                    target = info.targetpassword2[c-i];
                }
                if(info.currentpassword[l-i]!=target){
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}