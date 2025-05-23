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
    private Collider[] childColliders;
    public GameObject hammer;
    void Start()
    {
        childRenderers = GetComponentsInChildren<Renderer>(true);
        childColliders = GetComponentsInChildren<Collider>(true);
        foreach (Renderer renderer in childRenderers)
        {
            if (renderer.gameObject != this.gameObject)
            {
                renderer.enabled = false;
            }
        }
        foreach (Collider collider in childColliders)
        {
            if (collider.gameObject != this.gameObject)
            {
                collider.enabled = false;
            }
        }
        return;
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
            if (hit.collider != null && hit.collider.gameObject == this.gameObject && info.currentobject == targetobject && info.waterhight < -2.5f)
            {
                SwitchToNextSprite(); // 切换到下一个Sprite
                hammer.GetComponent<SpriteRenderer>().sortingOrder = 5;
                hammer.GetComponent<Hammer>().Drop();
            }
        }
    }

    private void SwitchToNextSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprites;
        childRenderers = GetComponentsInChildren<Renderer>(true);
        childColliders = GetComponentsInChildren<Collider>(true);
        foreach (Renderer renderer in childRenderers)
        {
            renderer.enabled = true;
        }
    }
}