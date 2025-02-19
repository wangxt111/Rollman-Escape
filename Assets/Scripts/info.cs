using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//存储全局信息

public static class info{
    public static GameObject currentobject = null; //当前选中的物体(背包中)

    public static int currentindex = -1; //当前选中的物体在背包中的位置
    
    public static int current_scene_num = 1 ;

    public static bool in_childscene = false; //在子场景中无法转动摄像头
    public static List<int> targetsong = new List<int> {0,1,2};
    public static List<int> currentsong = new List<int>();
    public static bool finishsong = false; //是否完成当前歌曲
    public static List<int> targetpassword = new List<int> {7,1,5};
    public static List<int> currentpassword = new List<int>();
    public static bool finishpassword = false; //是否完成密码输入
    public static int safe_box = 0; //0、1、2分别表示保险箱关闭、半开、全开
    public static Color32 brush_color = Color.clear; //画笔颜色
    public static bool[] correctcolor = new bool[7];
    public static bool ink = false; //是否拿到墨水
    public static bool tomato = false; //是否拿到番茄
    public static int copy_machine = 0;
    public static int manual = 0; //0、1、2、3表示综评手册未掉落、开始掉落（记录时间）、正在掉落、已经掉落（未实现）
    public static int manual_table = 0; //0、1、2分别表示没拿到综评手册、拿到综评手册（桌子上的综评手册collider显示）、桌子上综评手册显示
    public static bool is_switching = false; //是否正在切换镜子场景
    public static int horizontal_bar = 0; //0、1、2、3分别表示没上杆、上杆、做第一个引体向上、做第二个引体向上
    public static bool carpethidekeyboard = true; //地毯是否隐藏键盘
}