using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// 切换到放大的保险箱场景
public class Hole : MonoBehaviour
{
    public int hole_num;
    private Renderer[] childRenderers;
    void Start()
    {
        Renderer Renderer = GetComponent<Renderer>();
        Renderer.enabled = false;
        childRenderers = GetComponentsInChildren<Renderer>(true);
        foreach (Renderer renderer in childRenderers)
        {
            if (renderer.gameObject != this.gameObject)
            {
                renderer.enabled = false;
            }
        }
        return;
    }
    void Update()
    {
        if( info.puzzles[hole_num] )
        {
            Renderer Renderer = GetComponent<Renderer>();
            Renderer.enabled = true;
            childRenderers = GetComponentsInChildren<Renderer>(true);
            foreach (Renderer renderer in childRenderers)
            {
                renderer.enabled = true;
            }
        }
    }
}