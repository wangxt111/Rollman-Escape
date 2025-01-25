using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Constants;

public class buttonmanager: MonoBehaviour{
    void Start(){
        return;
    }
    void Update(){
        return;
    }
    public GameObject getfirstfreebutton(){
        GameObject testbutton = null;
        for(int i=0;i<Constants.Constants.buttonnumber;i++){
            testbutton = GameObject.FindWithTag("button"+i);
            if(testbutton.GetComponent<tablebutton>().storeobject == null){
                return testbutton;
            }
        }
        return testbutton;
    }
}