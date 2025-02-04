using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public static class Utils{
    public static Vector3 CameraPostionBeforeMovement = Vector3.zero;
    public static void MoveCamera(Vector3 position,bool isorthographic){
        GameObject camera = GameObject.Find("Main Camera");
        CameraPostionBeforeMovement = camera.transform.position;
        camera.transform.position = position;
        info.in_childscene = true;
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
        targetbutton.GetComponentInChildren<TextMeshProUGUI>().text = index.ToString();
        info.currentindex = -1;
        info.currentobject = null;
    }
}