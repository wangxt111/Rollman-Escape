using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public static class Utils{
    public static Vector3 CameraPostionBeforeMovement = Vector3.zero;
    public static void MoveCamera(Vector3 position,bool isorthographic = true,bool child2child = false,bool movetochild = true){
        GameObject camera = GameObject.Find("Main Camera");
        if( child2child == false ) CameraPostionBeforeMovement = camera.transform.position;
        camera.transform.position = position;
        info.in_childscene = movetochild;
        camera.GetComponent<Camera>().orthographic = isorthographic;
    }
    public static void ResetCamera(){
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.position = CameraPostionBeforeMovement;
        camera.GetComponent<Camera>().orthographic = true;
        info.in_childscene = false;
    }
    public static void ClearTableButton(int index){ //从tablebutton上移除物体，同时清空info中信息
        GameObject targetbutton = GameObject.FindGameObjectWithTag("button"+index);
        targetbutton.GetComponent<tablebutton>().storeobject = null;
        targetbutton.GetComponent<Image>().sprite = targetbutton.GetComponent<tablebutton>().defualtimage;
        info.currentindex = -1;
        info.currentobject = null;
    }
    public static void ChangeTableButton(int index, Sprite newSprite){ //修改格子内容
        GameObject targetbutton = GameObject.FindGameObjectWithTag("button"+index);
        targetbutton.GetComponent<Image>().sprite = newSprite;
    }
}