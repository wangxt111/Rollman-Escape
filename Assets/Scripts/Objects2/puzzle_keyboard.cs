using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// 切换到放大的保险箱场景
public class Puzzle_Keyboard : MonoBehaviour
{
    public int num;
    public Vector3 CameraPositionAfterClick = new Vector3(0, 148, 0);
    void Start()
    {
        return;
    }
    void Update()
    {
        if( info.puzzles[num] )
        {
            Renderer Renderer = GetComponent<Renderer>();
            Renderer.enabled = false;
            Collider Collider = GetComponent<Collider>();
            Collider.enabled = false;
        }
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
            if (hit.collider != null && hit.collider.gameObject == this.gameObject && ( ( info.level == 1 && info.safe_box1 != 2 ) || ( info.level == 2 && info.safe_box2 != 2 ) ) )
            {
                info.puzzle_num = num;
                Utils.MoveCamera(CameraPositionAfterClick,true);
            }
        }
    }
}