using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float TimeToClimb;

    public int NumPaddles;

    public GameObject originalPaddle;
    
    public Transform start;
    public Transform end;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumPaddles; i++)
        {
            Paddle paddle = Instantiate(originalPaddle).GetComponent<Paddle>();
            paddle.delay = i * TimeToClimb / NumPaddles;
            paddle.start = start;
            paddle.end = end;
        }
    }
}
