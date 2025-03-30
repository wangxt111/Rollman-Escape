using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Constants
{
    public class Constants
    {
        public static readonly Vector3Int level_1_camera = new Vector3Int(0, 0, 0);
        public static readonly Vector3Int level_2_camera = new Vector3Int(0, 100, 0);
        public static readonly Quaternion level_2_camera_rotation = Quaternion.Euler(0f, 0f, 0f);
        public static readonly Vector3Int level_3_camera = new Vector3Int(0, 200, 0);
        public const int buttonnumber = 20;
        public static readonly Color red = new Color32(209, 124, 65, 255);
        public static readonly Color green = new Color32(157, 173, 71, 255);
        public static readonly Color blue = new Color32(82, 107, 159, 255);
        public static readonly Color yellow = new Color32(243, 208, 98, 255);
        public static readonly Color white = new Color32(255, 255, 255, 255);
        public static readonly Color black = new Color32(0, 0, 0, 255);
    }
}