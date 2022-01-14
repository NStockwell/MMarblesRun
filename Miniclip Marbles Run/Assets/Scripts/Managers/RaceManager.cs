using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{

    public GameObject EndGameObject;
    public TextMeshProUGUI EndGameResult;
    
    private static RaceManager _instance;

    public static RaceManager Instance
    {
        get => _instance;
    }

    public GameObject marble1;
    public GameObject marble2;
    public GameObject marble3;
    public GameObject marble4;
    
    private List<GameObject> _marbles = new List<GameObject>();
    private Trigger _latestTrigger = null;
    private Marble winnerMarble;
    private Leaderboard _leaderboard = new Leaderboard();
    private const int k_maxLaps = 3;
    
    private void Awake() 
    { 
        if (_instance != null && _instance != this) 
        { 
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    } 
    
    // Start is called before the first frame update
    void Start()
    {
        _marbles.Add(marble1);
        _marbles.Add(marble2);
        _marbles.Add(marble3);
        _marbles.Add(marble4);

        StartingGrid.Instance.SetMarbles(_marbles);
        StartCoroutine(nameof(StartCountdown));
    }

    IEnumerator StartCountdown()
    {
        int i = 5;
        while (i > 0)
        {
            i--;
            StartingGrid.Instance.LightNextSemaphor();
            yield return new WaitForSecondsRealtime(1);
        }
        StartingGrid.Instance.StartRace();
    }
 

    // Update is called once per frame
    void Update()
    {
    }

    public void ResetMarble(GameObject marble)
    {
        // Add a lap and check for end condition
        Marble marbleScript = marble.GetComponent<Marble>();
        if (marbleScript != null)
        {
            if (marbleScript.GetNumLaps() == k_maxLaps)
            {
                if (winnerMarble == null)
                {
                    winnerMarble = marbleScript;
                    EndGameObject.SetActive(true);
                    EndGameResult.SetText($"Winner Marble is: " + marbleScript.ID + "!");
                }
                else
                {
                    //Debug.Log("Marble: " + marbleScript.ID + " finished!");
                }
                return;
            }
            
            marbleScript.AddLap();

            /*
                // Reset to Initial Position
            marble.transform.position = marbleScript.InitialPosition;
            Rigidbody rb = marble.GetComponent<Rigidbody>();
            Vector3 currentVelocity = rb.velocity;
            currentVelocity.z *= -1;
            rb.velocity = currentVelocity;
            */
        }
    }

    public void CheckpointReached(Trigger trigger, Marble marble)
    {
        if (_latestTrigger == null)
        {
            _latestTrigger = trigger;
        }
        else
        {
            if (_latestTrigger.order < trigger.order)
            {
                _latestTrigger = trigger;
            }
        }
        
        _leaderboard.MarbleReachedCheckPoint(trigger, marble);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
