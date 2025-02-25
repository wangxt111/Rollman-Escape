using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Copy_Machine : MonoBehaviour
{
    public Sprite[] newSprites; // 要切换的新图片数组
    private bool isSwitching = false; // 标记是否正在切换Sprite
    public GameObject[] targetpaper;

    void Start()
    {
    }

    void Update()
    {
        if (info.currentobject != null) Debug.Log(info.currentobject.name);
        
        // 检测鼠标左键是否被按下
        if (!isSwitching && Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                foreach (GameObject paper in targetpaper)
                {
                    if (info.currentobject == paper)
                    {
                        SwitchToNextSprite(); // 切换到下一个Sprite
                        return;
                    }
                }
            }
        }
    }

    private void SwitchToNextSprite()
    {
        if (newSprites.Length == 0) return;
        
        // 只在索引未到最后一个时切换
        if (info.copy_machine < newSprites.Length)
        {
            Utils.ClearTableButton(info.currentindex);
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = newSprites[info.copy_machine];
            info.copy_machine++;
        }
        if( info.copy_machine == newSprites.Length )
        {
            StartCoroutine(WaitAndSwitchToFinalSprite());
        }
    }

    private IEnumerator WaitAndSwitchToFinalSprite()
    {
        yield return new WaitForSeconds(0.6f);
        info.copy_machine ++ ;
    }
}