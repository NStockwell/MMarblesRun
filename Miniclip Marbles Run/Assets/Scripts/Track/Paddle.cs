using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float interval;
    public float delay;
    
    private float elapsedTime;
    
    public Transform start;
    public Transform end;

    private MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.fixedDeltaTime;
            if(delay > 0)
                return;
        }

        if (delay < 0)
        {
            elapsedTime = -delay;
            delay = 0;
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = true;
            elapsedTime += Time.fixedDeltaTime;    
        }
        
        if (elapsedTime >= interval)
        {
            elapsedTime -= interval;
        }
        
        transform.position = Vector3.Lerp(start.position, end.position, elapsedTime / interval);
    }
}
