﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isFinish;
    public int order;
    
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
        Marble marble = other.gameObject.GetComponent<Marble>();
        // Let the marble know he crossed the checkpoint
        if (marble != null)
        {
            marble.AddCheckpoint(this);
        }
        
        // Notify race manager that a checkpoint was reached
        RaceManager.Instance.CheckpointReached(this, other.gameObject.GetComponent<Marble>());
        
        if (isFinish)
        {
            // Reset Marble to starting position
            RaceManager.Instance.ResetMarble(other.gameObject);
        }
    }
}
