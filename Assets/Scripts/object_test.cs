using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class object_test : MonoBehaviour
{
    // Start is called before the first frame update
    // 开始方法
    void Start(){
        return;
    }
    void Update(){
        return;
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