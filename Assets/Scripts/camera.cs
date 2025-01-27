using UnityEngine;

public class CameraRoomController : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f) ;
    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.UpArrow) )
        {
            transform.rotation = Quaternion.Euler(0f,0f,90f) ;
            info.current_scene_num = 5 ;
        }
        else if( Input.GetKeyDown(KeyCode.DownArrow) && info.current_scene_num == 5 )
        {
            transform.rotation = Quaternion.Euler(0f,0f,0f) ;
            info.current_scene_num = 1 ;
        }
        else if( Input.GetKeyDown(KeyCode.LeftArrow) && info.current_scene_num != 5 )
        {
            transform.Rotate(0f,-90f,0f) ;
            info.current_scene_num -= 1 ;
            if( info.current_scene_num == 0 ) info.current_scene_num = 4 ;
        }
        else if( Input.GetKeyDown(KeyCode.RightArrow) && info.current_scene_num != 5 )
        {
            transform.Rotate(0f,90f,0f) ;
            info.current_scene_num += 1 ;
            if( info.current_scene_num == 5 ) info.current_scene_num = 1 ;
        }
    }
}