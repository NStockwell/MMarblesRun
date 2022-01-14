using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private static MenuController _instance;

    public static MenuController Instance
    {
        get => _instance;
    }

    public double Minigame1Score;
    public double Minigame2Score;

    public int[] othersScores;
    public float[] weightInVotes;
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
        othersScores = new [] {0,0,0,0,0,0,0};
        float balanceWeight = 1 / 8.0f;
        weightInVotes = new[] {balanceWeight,balanceWeight,balanceWeight,balanceWeight,balanceWeight,balanceWeight,balanceWeight,balanceWeight};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
