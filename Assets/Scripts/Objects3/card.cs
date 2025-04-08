using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{    private Renderer card_renderer;
    private Collider card_collider;
    public Vector3 start;  // Start位置
    public Vector3 end;    // End位置
    private bool isFalling = false;  // 判断物体是否正在下落

    void Start()
    {
        card_renderer = GetComponent<Renderer>();
        card_renderer.enabled = false;
        card_collider = GetComponent<Collider>();
        card_collider.enabled = false;

        // 如果start和end有值，可以在Start时设置物体位置为start
        transform.position = start;
    }

    void Update()
    {
        if (info.card == 0) return;

        if (info.card == 1 )
        {
            card_renderer.enabled = true;
            card_collider.enabled = true;
            transform.localPosition = start;
            info.card = 2;
        }
        if (info.card == 2 && !isFalling)
        {
            StartCoroutine(DropToEnd());
        }

        // 检测鼠标左键是否被按下
        if (Input.GetMouseButtonDown(0))
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
                info.piece[3] = true;
                ++ info.finish_piece_num;
                Utils.ResetCamera();
                this.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator DropToEnd()
    {
        isFalling = true;

        float fallDuration = 2f;
        float elapsedTime = 0f;
        Vector3 initialPosition = transform.localPosition;
        Vector3 targetPosition = end;

        float gravity = 9.8f;
        float speed = 0f;

        float distance = Vector3.Distance(initialPosition, targetPosition);

        while (elapsedTime < fallDuration)
        {
            speed += gravity * Time.deltaTime;
            float distanceFallen = speed * elapsedTime + 0.5f * gravity * Mathf.Pow(elapsedTime, 2);

            // 防止下落过多，确保物体最终不会超越目标位置
            if (distanceFallen > distance)
            {
                distanceFallen = distance;
            }

            // 当前下落位置
            Vector3 newPosition = initialPosition + (targetPosition - initialPosition).normalized * distanceFallen;
            transform.localPosition = newPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetPosition;
        isFalling = false;
        info.card = 3;
    }
}
