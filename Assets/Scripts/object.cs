using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public int scene_num;
    private Vector3 initialPosition;
    
    // Start is called before the first frame update
    // 开始方法
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        initialPosition = transform.position;
        return;
    }
    void Update()
    {
        if (scene_num == info.current_scene_num)
        {
            transform.position = initialPosition;
        }
        else
        {
            // 把物体移到一个很远的地方
            transform.position = new Vector3(-1000f, -1000f, -1000f);
        }
    }

    private void OnMouseDown()
    {
        GameObject freebutton = GameObject.Find("MainController").GetComponent<buttonmanager>().getfirstfreebutton();
        if (freebutton != null){
            Debug.Log("id"+freebutton.GetComponent<tablebutton>().buttonID);
            freebutton.GetComponent<tablebutton>().changetext(freebutton, this.gameObject.name);
            freebutton.GetComponent<tablebutton>().changestore(freebutton, this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}