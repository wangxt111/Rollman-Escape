using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    private Renderer tomato_renderer;
    void Start()
    {
        tomato_renderer = GetComponent<Renderer>();
        return;
    }
    void Update()
    {
        if( info.tomato == true )
        {
            tomato_renderer.enabled = false;
            return;
        }
    }
}