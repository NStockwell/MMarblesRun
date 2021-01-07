using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    private static RaceManager _instance;

    public static RaceManager Instance
    {
        get => _instance;
    }

    public GameObject marble1;
    public GameObject marble2;
    public GameObject marble3;
    public GameObject marble4;

    private Dictionary<GameObject, Vector3> _initialPositions = new Dictionary<GameObject, Vector3>();
    private Marble winnerMarble;
    private const int k_maxLaps = 10;
    
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
        _initialPositions.Add(marble1, marble1.transform.position);
        _initialPositions.Add(marble2, marble2.transform.position);
        _initialPositions.Add(marble3, marble3.transform.position);
        _initialPositions.Add(marble4, marble4.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetMarble(GameObject marble)
    {
        if (_initialPositions.ContainsKey(marble))
        {
            // Add a lap and check for end condition
            Marble marbleScript = marble.GetComponent<Marble>();
            if (marbleScript != null)
            {
                if (marbleScript.GetNumLaps() == k_maxLaps)
                {
                    if (winnerMarble == null)
                    {
                        Debug.Log("Winner Marble is: " + marbleScript.ID + "!");
                        winnerMarble = marbleScript;
                    }
                    else
                    {
                        Debug.Log("Marble: " + marbleScript.ID + " finished!");
                    }
                    return;
                }
                
                marbleScript.AddLap();
            }
            
            // Reset to Initial Position
            marble.transform.position = _initialPositions[marble];
            Rigidbody rb = marble.GetComponent<Rigidbody>();
            Vector3 currentVelocity = rb.velocity;
            currentVelocity.z *= -1;
            rb.velocity = currentVelocity;
        }
    }
}
