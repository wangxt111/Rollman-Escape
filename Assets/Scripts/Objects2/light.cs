using UnityEngine;


//已废弃
public class Light : MonoBehaviour
{
    public GameObject flashlight;
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool hasTarget = false;
    // 定义目标物体引用
    public GameObject targetObject;

    public GameObject[] targetObjects; // 目标物体列表
    private float detectionRadius = 1f; // 检测半径

    void Update()
    {
        if (info.currentobject==flashlight && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 使用 RaycastAll 方法获取所有与射线相交的碰撞体信息
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);

            // 遍历所有碰撞体信息
            foreach (RaycastHit hit in hits)
            {
                // 检查碰撞的物体是否为目标物体
                if (hit.collider != null && hit.collider.gameObject == targetObject)
                {
                    // 设置目标位置
                    targetPosition = hit.point;
                    hasTarget = true;
                    // 找到目标物体后可以选择跳出循环
                    break;
                }
            }
        }

        if (hasTarget)
        {
            if(!GetComponent<SpriteRenderer>().enabled){
                transform.position = targetPosition;
                GetComponent<SpriteRenderer>().enabled = true;
                hasTarget = false;
                return;
            }
            float distance = Vector3.Distance(transform.position, targetPosition);
            if (distance > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                hasTarget = false;
            }
        }

        if(!GetComponent<SpriteRenderer>().enabled){
            foreach (GameObject target in targetObjects){
                target.GetComponent<SpriteRenderer>().color = Color.white;
            }
            return;
        }

        // 以当前物体的位置为中心，在指定半径内进行球形检测
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider collider in collidersInRange)
        {
            foreach (GameObject target in targetObjects)
            {
                if (target == collider.gameObject)
                {
                    SpriteRenderer targetSpriteRenderer = collider.GetComponent<SpriteRenderer>();
                    if (targetSpriteRenderer != null)
                    {
                        targetSpriteRenderer.color = Color.red;
                    }
                    break;
                }
            }
        }

        // 检查是否有之前被染色的物体离开了检测范围，将其颜色恢复为白色
        foreach (GameObject target in targetObjects)
        {
            bool isInRange = false;
            foreach (Collider collider in collidersInRange)
            {
                if (target == collider.gameObject)
                {
                    isInRange = true;
                    break;
                }
            }
            if (!isInRange)
            {
                SpriteRenderer targetSpriteRenderer = target.GetComponent<SpriteRenderer>();
                if (targetSpriteRenderer != null)
                {
                    targetSpriteRenderer.color = Color.white;
                }
            }
        }
    }
}