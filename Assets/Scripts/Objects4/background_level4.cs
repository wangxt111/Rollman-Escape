using UnityEngine;

public class Background_Level4 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;       // 拖 SpriteRenderer
    public float fadeSpeed = 0.6f;                // 透明度上升速度
    public float cameraMoveSpeed = 1.5f;          // 相机移动速度
    public float scaleSpeed = 0.6f;               // 缩放速度

    private bool startAnimation = false;
    private bool fadeDone = false;
    private bool cameraDone = false;
    private bool scaleDone = false;

    private Transform camTransform;
    private Vector3 initialCameraPosition;
    private Vector3 targetCameraPosition;
    private Vector3 originalScale;
    private Vector3 targetScale;

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        // 初始透明
        Color color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;

        // 相机目标位置
        camTransform = Camera.main.transform;
        initialCameraPosition = Constants.Constants.level_4_camera;
        targetCameraPosition = initialCameraPosition + new Vector3(0f, 1.81f, 0f);

        // 初始和目标缩放
        originalScale = transform.localScale;
        targetScale = originalScale * 0.8f;
    }

    void Update()
    {
        if (info.finish_level4 && !startAnimation)
        {
            startAnimation = true;
        }

        if (startAnimation)
        {
            if (!fadeDone)
            {
                Color color = spriteRenderer.color;
                color.a = Mathf.MoveTowards(color.a, 1f, fadeSpeed * Time.deltaTime);
                spriteRenderer.color = color;

                if (Mathf.Approximately(color.a, 1f))
                {
                    fadeDone = true;
                }
            }

            if (!cameraDone)
            {
                camTransform.position = Vector3.MoveTowards(
                    camTransform.position,
                    targetCameraPosition,
                    cameraMoveSpeed * Time.deltaTime
                );

                if (camTransform.position == targetCameraPosition)
                {
                    cameraDone = true;
                }
            }

            if (!scaleDone)
            {
                transform.localScale = Vector3.MoveTowards(
                    transform.localScale,
                    targetScale,
                    scaleSpeed * Time.deltaTime
                );

                if (transform.localScale == targetScale)
                {
                    scaleDone = true;
                }
            }

            if (fadeDone && cameraDone && scaleDone)
            {
                startAnimation = false;
            }
        }
    }
}
