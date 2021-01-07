using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public bool isFinish;
    private GameObject winnerMarble;
    
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
            if (winnerMarble == null)
            {
                winnerMarble = other.gameObject;
                Debug.Log("Winner Marble is: " + winnerMarble.name);
            }   
        }
    }
}
