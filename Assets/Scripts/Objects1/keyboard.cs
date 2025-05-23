using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public int KeyboardID;
    public bool isfinished;
    Renderer keyboardrenderer;
    public Sprite newSprite; // 在Inspector中赋值为要切换的新图片
    public float switchDuration = 0.5f; // 切换持续时间

    private Sprite originalSprite; // 用于存储原始Sprite
    private bool isSwitching = false; // 标记是否正在切换Sprite
    public List<GameObject> targetkeyboards;
    public GameObject piano;
    public AudioSource audiosource;
    void Start()
    {
        originalSprite = GetComponent<SpriteRenderer>().sprite;
        keyboardrenderer = GetComponent<Renderer>();
        if(!isfinished){
            keyboardrenderer.enabled = false;
        }
        return;
    }
    void Update()
    {
        // 检测鼠标左键是否被按下
        if (info.in_childscene && !isSwitching && Input.GetMouseButtonDown(0))
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
                if(isfinished){
                    SwitchSprite();
                    audiosource.Play(); //播放音频
                    if(info.finishsong) return;
                    info.currentsong.Add(KeyboardID);
                }else if(targetkeyboards.Contains(info.currentobject)){
                    GameObject.Find("keyboard_perspective"+KeyboardID).GetComponent<Renderer>().enabled = true;
                    keyboardrenderer.enabled = true;
                    isfinished = true;
                    Utils.ClearTableButton(info.currentindex);
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
        if(CheckSong()){
            info.finishsong = true;
            //切回原场景
            info.in_childscene = false ;
            info.currentsong.Clear();
            info.currentpassword.Clear();
            Utils.ResetCamera() ; //重置摄像头回原位
            piano.GetComponent<Piano_perspective>().BirdAppear();
        }
    }
    bool CheckSong(){
        int l = info.currentsong.Count;
        int c = info.targetsong.Count;
        if(l>=c){
            for(int i=1;i<=c;i++){
                if(info.currentsong[l-i]!=info.targetsong[c-i]){
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}