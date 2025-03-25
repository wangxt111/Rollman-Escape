using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Sprite image;
    public Vector3 end;    // End位置
    void Start()
    {
        return;
    }
    void Update()
    {
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
                GameObject freebutton = GameObject.Find("MainController").GetComponent<buttonmanager>().getfirstfreebutton();
                if (freebutton != null)
                {
                    freebutton.GetComponent<tablebutton>().changeimage(freebutton, image);
                    freebutton.GetComponent<tablebutton>().changestore(freebutton, this.gameObject);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
    public void Drop(){
        StartCoroutine(DropToEnd());
    }
    private IEnumerator DropToEnd()
    {

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
        GetComponent<Collider>().enabled = true;
    }
}