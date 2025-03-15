using UnityEngine;
using System.Collections;

public class Instruction_button : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Vector3 CameraPositionAfterClick = new Vector3(0, 20, 0);
    
    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalSprite = spriteRenderer.sprite;
        }
    }

    // 鼠标悬停时更改Sprite
    void OnMouseEnter()
    {
        if (spriteRenderer != null && sprite1 != null)
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    // 鼠标移出时恢复Sprite
    void OnMouseExit()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = originalSprite;
        }
    }

    // 鼠标点击时更改Sprite并移动摄像头
    void OnMouseDown()
    {
        if (spriteRenderer != null && sprite2 != null)
        {
            spriteRenderer.sprite = sprite2;
            StartCoroutine(SwitchCameraPosition());
        }
    }

    IEnumerator SwitchCameraPosition()
    {
        yield return new WaitForSeconds(0.3f);

        // 将摄像头移动到新的位置
        Utils.MoveCamera(CameraPositionAfterClick,true);
    }
}
