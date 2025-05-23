using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Addmission : MonoBehaviour
{
    public GameObject piano;
    public GameObject window;
    public GameObject water;
    public GameObject bird;
    public GameObject Scene2;
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
                bird.SetActive(false);
                GameObject camera = GameObject.Find("Main Camera");
                camera.transform.SetPositionAndRotation(Constants.Constants.level_1_camera, Quaternion.Euler(0f, 90f, 0f));
                info.in_childscene = false;
                camera.GetComponent<Camera>().orthographic = true;
                water.GetComponent<Water>().WaterAppear();
                info.switchingtolevel2 = true;
                DisableAllChildBoxColliders(Scene2);
                window.GetComponent<Window>().WindowClose();
                piano.GetComponent<Piano_perspective>().PianoClose();
                StartCoroutine(MoveCameraAfterDelay());
            }
        }
    }
    private IEnumerator MoveCameraAfterDelay()
    {
        yield return new WaitForSeconds(7f);
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.SetPositionAndRotation(Constants.Constants.level_2_camera, Constants.Constants.level_2_camera_rotation);
        camera.GetComponent<Camera>().orthographic = true;
        info.in_childscene = false;
        info.switchingtolevel2 = false;
        info.timerIsRunning = true;
        info.level = 2;
    }

    public void DisableAllChildBoxColliders(GameObject targetObject)
    {
        // 检查目标物体是否为空
        if (targetObject != null)
        {
            // 遍历目标物体的所有子物体
            foreach (Transform child in targetObject.transform)
            {
                // 获取子物体的 BoxCollider 组件
                BoxCollider boxCollider = child.GetComponent<BoxCollider>();
                // 检查子物体是否有 BoxCollider 组件
                if (boxCollider != null)
                {
                    // 禁用 BoxCollider 组件
                    boxCollider.enabled = false;
                }
            }
        }
    }
}