using System;
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

    public int SecondsToStart;
    public GameObject Semaphor;
    private List<GameObject> semaphors;
    private int litSemaphors = 0;

    private void Awake()
    {
        Vector3 initialPosition = Vector3.up*0.5f;
        float xOffset = 0.06f;
        semaphors = new List<GameObject>();
        for (int i = 0; i < SecondsToStart; i++)
        {
            var semaphor = Instantiate(Semaphor);
            semaphor.transform.position = initialPosition + Vector3.right*xOffset * (i - (SecondsToStart-1)*0.5f) ;
            semaphors.Add(semaphor);
        }
    }

    public void LightNextSemaphor()
    {
        var sems = semaphors[litSemaphors].GetComponentsInChildren<Semaphor>();
        foreach (var semaphor in sems)
        {
            semaphor.GoRed();
        } 
        litSemaphors++;
    }

    public void StartRace()
    {
        foreach (var semaphor in semaphors)
        {
            var sems = semaphor.GetComponentsInChildren<Semaphor>();
            foreach (var s in sems)
            {
                s.GoGreen();
            } 
        }
        
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