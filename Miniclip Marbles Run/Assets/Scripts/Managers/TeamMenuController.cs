using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class TeamMenuController : MonoBehaviour
{
    public Button LeftScroller;
    public Button RightScroller;
    public Button PlayButton;
    public ScrollRect ScrollView;

    private int _currentNavIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        LeftScroller.gameObject.SetActive(false);
        LeftScroller.onClick.AddListener(OnClickLeft);
        RightScroller.onClick.AddListener(OnClickRight);
        PlayButton.onClick.AddListener(OnClickPlayButton);
        ScrollView.onValueChanged.AddListener(OnValueChangedScrollView);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickLeft()
    {
        
    }

    private void OnClickRight()
    {
        
    }
    
    private void OnClickPlayButton()
    {
        PlayButton.onClick.AddListener(() => SceneManager.LoadScene("SampleSceneSeixas"));
    }

    public void OnValueChangedScrollView(Vector2 value)
    {
        Debug.Log("ListenerMethod: " + value);
    }
}
