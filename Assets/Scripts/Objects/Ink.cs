using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ink : MonoBehaviour
{
    private Renderer ink_renderer;
    void Start()
    {
        ink_renderer = GetComponent<Renderer>();
        return;
    }
    void Update()
    {
        if( info.ink == true )
        {
            ink_renderer.enabled = false;
            return;
        }
    }
}