using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    Button button;
    public string botton_type;
    public string CurrentWallScene;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SwitchScene);
    }
    public void SwitchScene()
    {
        if( botton_type == "left" && info.current_scene_num != 5 )
        {
            info.current_scene_num -= 1 ;
            if( info.current_scene_num == 0 ) info.current_scene_num = 4 ;
        }
        if( botton_type == "right" && info.current_scene_num != 5 )
        {
            info.current_scene_num += 1 ;
            if( info.current_scene_num == 5 ) info.current_scene_num = 1 ;
        }
        if( botton_type == "up" )
        {
            info.current_scene_num = 5 ;
        }
        if( botton_type == "down" )
        {
            info.current_scene_num = 1 ;
        }
    }
}