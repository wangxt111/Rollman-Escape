using UnityEngine;

public class CameraRoomController : MonoBehaviour
{
    int scene_before_up = 1;
    void Start()
    {
        info.current_scene_num = 1 ;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f) ;
        transform.position = new Vector3(0f, 0f, 0f) ;
        GetComponent<Camera>().orthographic = true;
    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.UpArrow) && info.current_scene_num != 5 && !info.in_childscene )
        {
            scene_before_up = info.current_scene_num ;
            transform.Rotate(-90f,0f,0f);
            info.current_scene_num = 5 ;
        }
        else if( Input.GetKeyDown(KeyCode.DownArrow) )
        {
            if(info.in_childscene){
                info.in_childscene = false ;
                info.currentsong.Clear();
                info.currentpassword.Clear();
                Utils.ResetCamera() ; //重置摄像头回原位
            }else if(info.current_scene_num == 5){
                transform.Rotate(90f,0f,0f) ;
                info.current_scene_num = scene_before_up ;
            }
        }
        else if( Input.GetKeyDown(KeyCode.LeftArrow) && info.current_scene_num != 5 && !info.in_childscene)
        {
            transform.Rotate(0f,-90f,0f) ;
            info.current_scene_num -= 1 ;
            if( info.current_scene_num == 0 ) info.current_scene_num = 4 ;
        }
        else if( Input.GetKeyDown(KeyCode.RightArrow) && info.current_scene_num != 5 && !info.in_childscene)
        {
            transform.Rotate(0f,90f,0f) ;
            info.current_scene_num += 1 ;
            if( info.current_scene_num == 5 ) info.current_scene_num = 1 ;
        }
    }
}