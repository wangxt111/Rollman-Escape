using UnityEngine;

public class DragObject : MonoBehaviour
{
    // 标记是否正在拖动物体
    private bool isDragging = false;
    // 记录鼠标点击时物体与鼠标的偏移量（相对于父物体）
    private Vector3 offset;
    public GameObject blackboard;

    void Start()
    {
        return;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // 如果射线击中了当前物体
                if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                {
                    // 开始拖动
                    isDragging = true;
                    // 计算鼠标点击位置与物体位置的偏移量
                    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 停止拖动
            isDragging = false;
        }

        if (isDragging)
        {
            // 获取鼠标在世界坐标系中的位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 根据偏移量计算物体应该移动到的位置
            Vector3 targetPosition = mousePosition + offset;
            targetPosition.z = transform.position.z;

            //判断是否在黑板内
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);
            bool inblackboard = false;
            // 遍历所有碰撞体信息
            foreach (RaycastHit h in hits)
            {
                // 检查碰撞的物体是否为目标物体
                if (h.collider != null && h.collider.gameObject == blackboard)
                {
                    inblackboard = true;
                    break;
                }
            }
            // 更新物体的位置
            if(inblackboard) transform.position = targetPosition;
        }
    }
}