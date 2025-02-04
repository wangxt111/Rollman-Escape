using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Utils{
    public static Vector3 CameraPostionBeforeMovement = Vector3.zero;
    public static void MoveCamera(Vector3 position){
        GameObject camera = GameObject.Find("Main Camera");
        CameraPostionBeforeMovement = camera.transform.position;
        camera.transform.position = position;
        info.in_childscene = true;
    }
    public static void ResetCamera(){
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.position = CameraPostionBeforeMovement;
        info.in_childscene = false;
    }
}