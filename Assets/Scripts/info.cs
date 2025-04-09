using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//存储全局信息

public static class info{
    public static int level = 1;
    public static GameObject currentobject = null; //当前选中的物体(背包中)

    public static int currentindex = -1; //当前选中的物体在背包中的位置
    
    public static int current_scene_num = 1 ;
    public static bool in_childscene = false; //在子场景中无法转动摄像头

    // 第一关
    public static List<int> targetsong = new List<int> {2,4,9,13,14,13,11,9,8};
    public static List<int> currentsong = new List<int>();
    public static bool finishsong = false; //是否完成当前歌曲
    public static List<int> targetpassword1 = new List<int> {7,1,5};
    public static List<int> targetpassword2 = new List<int> {6,2,1,2};
    public static List<int> currentpassword = new List<int>();
    public static bool finishpassword1 = false; //是否完成场景1密码输入
    public static bool finishpassword2 = false; //是否完成场景2密码输入
    public static int safe_box1 = 0; //0、1、2分别表示保险箱关闭、半开、全开
    public static int safe_box2 = 0; //0、1、2分别表示保险箱关闭、半开、全开
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
    public static int manual_object_num = 0;
    public static int debuglevel = 4;
    public static bool switchingtolevel2 = false; //是否正在切换到level2
    public static float waterhight = 0f; //水的高度

    // 第二关
    public static float timeRemaining = 60f; // 第二关倒计时时间（秒）
    public static bool timerIsRunning = false;
    public static bool puzzle_enlarge = false; //是否放大谜题
    public static int puzzle_num = 0; // 当前放大的键盘编号
    public static bool[] puzzles = new bool[3];
    public static List<int>[] puzzles_answer = new List<int>[]
    {
        new List<int> {1, 9},
        new List<int> {2},
        new List<int> {9}
    };
    public static bool waterlevel2 = true;
    public static bool getflashlight = false; //level2中是否获得手电筒

    // 第三关
    public static int finish_piece_num = 0;
    public static bool[] piece = new bool[9]; // 为true表示改碎片对应关卡通关，切换碎片sprite
    public static bool[] drawer = new bool[2];
    public static int card = 0;
    public static int candy = 0;
    public static int book_num = 0;
    public static bool piece7_key = false;
    public static bool piece7_plane = false;
    
    // 第四关
    public static bool MovingBlock = false;
    public static bool finish_level4 = true;
    public static int block_type = -1;
}