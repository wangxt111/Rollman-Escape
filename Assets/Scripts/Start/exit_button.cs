using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour
{
    public Sprite sprite1; // 鼠标悬停时的Sprite
    public Sprite sprite2; // 鼠标点击时的Sprite

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

    // 鼠标点击时更改Sprite并退出游戏
    void OnMouseDown()
    {
        if (spriteRenderer != null && sprite2 != null)
        {
            spriteRenderer.sprite = sprite2;
            StartCoroutine(QuitGame());
        }
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(0.1f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 在编辑器中停止运行
#else
        Application.Quit(); // 在打包的游戏中退出
#endif
    }
}
