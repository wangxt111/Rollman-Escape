using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// 切换到放大的保险箱场景
public class Puzzle : MonoBehaviour
{
    public int puzzle_num;
    void Start()
    {
        return;
    }
    void Update()
    {
        if( info.puzzles[puzzle_num] )
        {
            Renderer Renderer = GetComponent<Renderer>();
            Renderer.enabled = false;
        }
    }
}