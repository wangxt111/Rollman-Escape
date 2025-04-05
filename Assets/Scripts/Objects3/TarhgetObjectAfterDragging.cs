using System.Linq;
using UnityEngine;

public class TarhgetObjectAfterDragging : MonoBehaviour
{
    private BoxCollider boxCollider;
    public GameObject background;
    public int targetpiece;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
        return;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);
            if(hits.Length == 1){
                if(hits[0].collider != null && hits[0].collider.gameObject == background){
                    boxCollider.enabled = true;
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        // 如果射线击中了当前物体
                        if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                        {
                            info.piece[targetpiece] = true;
                            this.gameObject.SetActive(false);
                            Utils.ResetCamera();
                        }
                    }
                    boxCollider.enabled = false;
                }
            }
        }
    }
}