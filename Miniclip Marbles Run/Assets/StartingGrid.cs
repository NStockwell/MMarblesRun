using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingGrid : MonoBehaviour
{
    private static StartingGrid instance;
    public static StartingGrid Instance
    {
        get
        {
            if (instance != null) 
                return instance;
                
            instance = FindObjectOfType<StartingGrid>();
            return instance;
        }  
    }
    
    public List<Transform> marblesPositions;
    public List<Bumper> bumpers;

    public void StartRace()
    {
        foreach (var bumper in bumpers)
        {
            bumper.Descend();
        }
    }

    public void SetMarbles(List<GameObject> marbles)
    {
        if (marbles.Count > marblesPositions.Count)
        {
            Debug.LogError($"Missing Starting Positions");
            return;
        }

        for (int i = 0; i < marbles.Count; i++)
        {
            marbles[i].transform.position = marblesPositions[i].position;
            marbles[i].GetComponent<Marble>().InitialPosition = marblesPositions[i].position;
        }
    }
}