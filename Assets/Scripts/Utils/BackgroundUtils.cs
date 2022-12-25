using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUtils : MonoBehaviour
{
    public Renderer backgroundRenderer;

    void Start()
    {
        
    }


    void Update()
    {
        if(backgroundRenderer != null)
        {
            backgroundRenderer.material.mainTextureOffset = new Vector2(0f, 0.1f * Time.time);
        }
    }
}
