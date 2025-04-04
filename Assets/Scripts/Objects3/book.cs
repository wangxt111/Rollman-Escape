using UnityEngine;

public class Book : MonoBehaviour
{
    public Vector3 targetPosition1 = new Vector3(0.32f, 0f, 0f);
    public Vector3 targetPosition2 = new Vector3(0f, 0f, 0f);
    private Vector3 targetPosition;
    private float moveSpeed = 6f;
    private bool isSwitching = false;

    private void Start()
    {
        targetPosition = targetPosition1;
    }

    private void Update()
    {
        if (!isSwitching && Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }

        if (isSwitching)
        {
            SmoothMoveToTarget();
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
                // 根据当前位置设置目标位置
                if (Vector3.Distance(transform.localPosition, targetPosition1) < 0.01f)
                {
                    targetPosition = targetPosition2;
                }
                else
                {
                    targetPosition = targetPosition1;
                }
                
                isSwitching = true;
            }
        }
    }

    private void SmoothMoveToTarget()
    {
        // 使用Lerp进行平滑移动
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * moveSpeed);

        // 如果物体接近目标位置，停止移动
        if (Vector3.Distance(transform.localPosition, targetPosition) < 0.01f)
        {
            isSwitching = false;
            if ( targetPosition == targetPosition1 )
            {
                -- info.book_num;
            }
            else
            {
                ++ info.book_num;
            }
        }
    }
}