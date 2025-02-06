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
    public static List<int> targetpassword = new List<int> {0,1,2,10};
    public static List<int> currentpassword = new List<int>();
    public static bool finishpassword = false; //是否完成密码输入
    public static int safe_box = 0; //0、1、2分别表示保险箱关闭、半开、全开
    public static Color32 brush_color = Color.clear; //画笔颜色
    public static bool[] correctcolor = new bool[7];
    public static bool finishpaint = false; //是否完成画图
}