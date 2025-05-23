using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int pieceID;
    public GameObject targetpiece;
    public Sprite newSprite;
    Vector3 CameraPositionAfterClick;
    Renderer objectrenderer;
    void Start()
    {
        if(targetpiece != null) CameraPositionAfterClick = new Vector3(targetpiece.transform.position.x, targetpiece.transform.position.y, 0f);
        objectrenderer = GetComponent<Renderer>();
        return;
    }
    void Update()
    {
        if( info.finish_piece_num == 8 )
        {
            StartCoroutine(Wait());
        }
        if (info.piece[pieceID] == true)
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
            return;
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
                Utils.MoveCamera(CameraPositionAfterClick);
            }
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        info.level = 4;
        Camera.main.transform.position = Constants.Constants.level_4_camera;
        this.gameObject.SetActive(false);
    }
}