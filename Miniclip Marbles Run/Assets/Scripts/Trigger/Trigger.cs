using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isFinish;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (isFinish)
        {
            // Reset Marble to starting position
            RaceManager.Instance.ResetMarble(other.gameObject);
        }
    }
}
