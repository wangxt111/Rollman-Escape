using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// 切换到放大的保险箱场景
public class Report : MonoBehaviour
{
    public Sprite image;
    Vector3 CameraPositionAfterClick = new Vector3(0, 48, 0);
    private Renderer report_renderer;
    private Collider report_collider;
    public Sprite[] newSprites;
    public Sprite first_image;
    void Start()
    {
        report_renderer = GetComponent<Renderer>();
        report_renderer.enabled = false;
        report_collider = GetComponent<Collider>();
        report_collider.enabled = false;
        return;
    }
    void Update()
    {
        if( info.copy_machine == 4 )
        {
            report_renderer.enabled = true;
            StartCoroutine(WaitAndSwitchSpritesSequentially(newSprites));
            report_collider.enabled = true;
            info.copy_machine ++ ;
        }
        else if( info.copy_machine != 5 ) return;
        // 检测鼠标左键是否被按下
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }
    private IEnumerator WaitAndSwitchSpritesSequentially(Sprite[] sprites)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        foreach (Sprite spr in sprites)
        {
            spriteRenderer.sprite = spr;
            yield return new WaitForSeconds(0.25f);
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
                    this.gameObject.SetActive(false);
                }
                Utils.MoveCamera(CameraPositionAfterClick,true);
            }
        }
    }
}