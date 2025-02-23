using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class tablebutton : MonoBehaviour
{
    // Start is called before the first frame update
    // 开始方法
    public int buttonID;
    public Sprite defualtimage;
    public GameObject storeobject = null;
    Button button;
    void Start()
    {
        changetext(this.gameObject,"");
        changeimage(this.gameObject,defualtimage);
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
    public void changeimage(GameObject targetbutton, Sprite newimage){
        Image image  = targetbutton.GetComponent<Image>();
        image.sprite = newimage;
    }
    public void changestore(GameObject targetbutton, GameObject newobject){
        targetbutton.GetComponent<tablebutton>().storeobject = newobject;
    }

    void TaskOnClick()
    {
        // Button被点击时执行的操作
        if(info.currentobject != null && storeobject == null){
            storeobject = info.currentobject;
            changeimage(this.gameObject, GameObject.FindGameObjectWithTag("button"+info.currentindex).GetComponent<Image>().sprite);
            changeimage(GameObject.FindGameObjectWithTag("button"+info.currentindex), defualtimage);
            changestore(GameObject.FindGameObjectWithTag("button"+info.currentindex), null);
            info.currentindex = -1;
            info.currentobject = null;
        }else if(storeobject != null){
            info.currentobject = storeobject;
            info.currentindex = buttonID;
        }
    }
}
