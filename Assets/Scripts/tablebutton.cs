using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tablebutton : MonoBehaviour
{
    // Start is called before the first frame update
    // 开始方法
    public int buttonID;
    public GameObject storeobject = null;
    Button button;
    void Start()
    {
        changetext(this.gameObject, buttonID.ToString());
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        return;
    }

    public void changetext(GameObject targetbutton, string newtext){
        TextMeshProUGUI text = targetbutton.GetComponentInChildren<TextMeshProUGUI>();
        text.text = newtext;
    }
    public void changestore(GameObject targetbutton, GameObject newobject){
        targetbutton.GetComponent<tablebutton>().storeobject = newobject;
    }

    void TaskOnClick()
    {
        // Button被点击时执行的操作
        if(info.currentobject != null && storeobject == null){
            Debug.Log(""+info.currentindex+" "+buttonID);
            storeobject = info.currentobject;
            changetext(GameObject.FindGameObjectWithTag("button"+info.currentindex), info.currentindex.ToString());
            changestore(GameObject.FindGameObjectWithTag("button"+info.currentindex), null);
            changetext(this.gameObject, storeobject.name);
            info.currentindex = -1;
            info.currentobject = null;
        }else if(storeobject != null){
            info.currentobject = storeobject;
            info.currentindex = buttonID;
        }
    }
}
