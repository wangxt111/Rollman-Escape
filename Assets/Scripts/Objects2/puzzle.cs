using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Puzzle : MonoBehaviour
{
    public int num;
    public Vector3 CameraPositionAfterClick = new Vector3(-5.5f, 102f, 8f);
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
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                if(!info.in_childscene)
                {
                    info.puzzle_enlarge = true;
                    info.waterlevel2 = false;
                    Utils.MoveCamera(CameraPositionAfterClick,false);
                }
            }
        }
    }
}