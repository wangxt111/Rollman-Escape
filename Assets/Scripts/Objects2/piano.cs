using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public Sprite newSprites;
    private bool isSwitching = false;
    public GameObject targetobject;
    private Renderer[] childRenderers;
    void Start()
    {
        childRenderers = GetComponentsInChildren<Renderer>(true);
        foreach (Renderer renderer in childRenderers)
        {
            if (renderer.gameObject != this.gameObject)
            {
                renderer.enabled = false;
            }
        }
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
            if (hit.collider != null && hit.collider.gameObject == this.gameObject && info.currentobject == targetobject)
            {
                SwitchToNextSprite(); // 切换到下一个Sprite
            }
        }
    }

    private void SwitchToNextSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprites;
        childRenderers = GetComponentsInChildren<Renderer>(true);
        foreach (Renderer renderer in childRenderers)
        {
            renderer.enabled = true;
        }
    }
}