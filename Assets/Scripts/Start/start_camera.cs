using UnityEngine;

public class CameraController : MonoBehaviour
{
    int scene_before_up = 1;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f) ;
        transform.position = new Vector3(0f, 0f, 0f);
        GetComponent<Camera>().orthographic = true;
    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.DownArrow) )
        {
            if(info.in_childscene){
                info.in_childscene = false ;
                info.currentsong.Clear();
                info.currentpassword.Clear();
                Utils.ResetCamera() ; //重置摄像头回原位
            }
            else 
            {
                info.current_scene_num = scene_before_up ;
            }
        }
    }
}