using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaceManagerScript : MonoBehaviour
{
    private static RaceManagerScript _instance;

    public static RaceManagerScript Instance
    {
        get => _instance;
    }

    public GameObject marble1;
    public GameObject marble2;
    public GameObject marble3;
    public GameObject marble4;

    private Dictionary<GameObject, Vector3> _initialPositions = new Dictionary<GameObject, Vector3>();
    
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
            marble.transform.position = _initialPositions[marble];
            Rigidbody rb = marble.GetComponent<Rigidbody>();
            Vector3 currentVelocity = rb.velocity;
            currentVelocity.z *= -1;
            rb.velocity = currentVelocity;
        }
    }
}
