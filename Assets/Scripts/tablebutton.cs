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
    private GameObject storeobject = null;
    void Start()
    {
        changetext(buttonID.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changetext(string newtext){
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = newtext;
    }
}
