using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTimer : MonoBehaviour
{
    [SerializeField]
    private float timer = 5f;
    
    [SerializeField]
    private float delay = 10f;

    public float Delay => delay;
    public float Timer => timer;
    
    public bool HasDelayExpired()
    {
        return delay <= 0;
    }

    public bool HasTimerExpired()
    {
        return timer < 0;
    }
   

    void FixedUpdate()
    {
        if (!HasDelayExpired())
        {
            delay -= Time.fixedDeltaTime;
            return;
        }
        
        if (HasTimerExpired())
        {
            return;
        }

        timer -= Time.fixedDeltaTime;
    }
}
