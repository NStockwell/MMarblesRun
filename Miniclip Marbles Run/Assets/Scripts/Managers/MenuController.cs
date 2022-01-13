﻿using System.Collections;
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

    public Button PlayButton;
    public double Minigame1Score;
    public double Minigame2Score;
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
        PlayButton.onClick.AddListener(() => SceneManager.LoadScene("TeamSelectionScene"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
