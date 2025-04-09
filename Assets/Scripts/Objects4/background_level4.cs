using UnityEngine;
using System.Collections;

public class Background_Level4 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;       // 拖 SpriteRenderer
    public float fadeDuration = 2f;             // 渐变总时间
    public float cameraMoveDuration = 2f;       // 相机移动时间
    public float scaleDuration = 2f;            // 缩放时间

    private Transform camTransform;
    private Vector3 initialCameraPosition;
    private Vector3 targetCameraPosition;
    private Vector3 originalScale;
    private Vector3 targetScale;

    private bool animationStarted = false;

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        // 初始透明
        Color color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;

        // 相机初始和目标位置
        camTransform = Camera.main.transform;
        initialCameraPosition = Constants.Constants.level_4_camera;
        camTransform.position = initialCameraPosition;
        targetCameraPosition = initialCameraPosition + new Vector3(0f, 2.81f, 0f);

        // 初始和目标缩放
        originalScale = transform.localScale;
        targetScale = new Vector3(0.75f, 0.75f, 0.75f);
    }

    void Update()
    {
        if (info.finish_level4 && !animationStarted && !info.MovingBlock)
        {
            animationStarted = true;
            StartCoroutine(PlayAnimation());
        }
    }

    IEnumerator PlayAnimation()
    {
        // 同时启动3个动画
        Coroutine fade = StartCoroutine(FadeIn());
        Coroutine move = StartCoroutine(MoveCamera());
        Coroutine scale = StartCoroutine(ScaleDown());

        // 等待全部完成
        yield return fade;
        yield return move;
        yield return scale;

        // 所有动画完成后可以加后续逻辑
        Debug.Log("All animations done.");
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color color = spriteRenderer.color;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsed / fadeDuration);
            spriteRenderer.color = color;
            yield return null;
        }
    }

    IEnumerator MoveCamera()
    {
        float elapsed = 0f;
        Vector3 start = camTransform.position;
        while (elapsed < cameraMoveDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / cameraMoveDuration);
            camTransform.position = Vector3.Lerp(start, targetCameraPosition, t);
            yield return null;
        }
    }

    IEnumerator ScaleDown()
    {
        float elapsed = 0f;
        Vector3 start = transform.localScale;
        while (elapsed < scaleDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / scaleDuration);
            transform.localScale = Vector3.Lerp(start, targetScale, t);
            yield return null;
        }
    }
}
