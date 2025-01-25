using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // 引入事件系统命名空间

public class ClickOnEmptySpace : MonoBehaviour
{
    void Update()
    {
        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            // 将鼠标屏幕坐标转换为世界坐标
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // 发射射线
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            
            // 检查射线是否击中了任何物体
            if (hit.collider == null)
            {
                // 检查是否点击了UI元素
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    // 获取点击的UI元素
                    GameObject clickedUI = EventSystem.current.currentSelectedGameObject;

                    // 检查点击的UI元素是否为Button
                    if (clickedUI != null && clickedUI.GetComponent<Button>())
                    {
                        Debug.Log("Clicked on a Button: " + clickedUI.name);
                        // 在这里添加当点击Button的逻辑
                    }
                    else
                    {
                        Debug.Log("Clicked on a UI element that is not a Button.");
                        // 在这里添加当点击非Button UI元素的逻辑
                    }
                }
                else
                {
                    Debug.Log("Clicked on empty space.");
                    // 在这里添加当点击空地方的逻辑
                }
            }
            else
            {
                Debug.Log("Clicked on an object: " + hit.collider.gameObject.name);
                // 在这里添加当点击物体的逻辑
            }
        }
    }
}
