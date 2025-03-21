using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Hole : MonoBehaviour
{
    public int hole_num;
    private Renderer[] childRenderers;
    private Collider[] childColliders;
    void Start()
    {
        Renderer Renderer = GetComponent<Renderer>();
        Renderer.enabled = false;
        childRenderers = GetComponentsInChildren<Renderer>(true);
        childColliders = GetComponentsInChildren<Collider>(true);

        foreach (Renderer renderer in childRenderers)
        {
            if (renderer.gameObject != this.gameObject)
            {
                renderer.enabled = false;
            }
        }

        foreach (Collider collider in childColliders)
        {
            if (collider.gameObject != this.gameObject)
            {
                collider.enabled = false;
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
            foreach (Collider collider in childColliders)
            {
                collider.enabled = true;
            }
        }
    }
}