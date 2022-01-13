using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class TeamMenuController : MonoBehaviour
{
    public Button LeftScroller;
    public Button RightScroller;
    public Button PlayButton;

    private int _currentNavIndex = 0;
    private readonly Color k_orange = new Color(1, 0.64F, 0, 1);
    private readonly Color k_yellow = new Color(1, 0.92F, 0.08F, 1);

    private GameObject[] _teams = new GameObject[8];

    // Start is called before the first frame update
    void Start()
    {
        LeftScroller.gameObject.SetActive(false);
        LeftScroller.onClick.AddListener(OnClickLeft);
        LeftScroller.gameObject.SetActive(false);
        RightScroller.onClick.AddListener(OnClickRight);
        PlayButton.onClick.AddListener(OnClickPlayButton);

        _teams[0] = GameObject.Find("Team1");
        _teams[1] = GameObject.Find("Team2");
        _teams[2] = GameObject.Find("Team3");
        _teams[3] = GameObject.Find("Team4");
        _teams[4] = GameObject.Find("Team5");
        _teams[4].SetActive(false);
        _teams[5] = GameObject.Find("Team6");
        _teams[5].SetActive(false);
        _teams[6] = GameObject.Find("Team7");
        _teams[6].SetActive(false);
        _teams[7] = GameObject.Find("Team8");
        _teams[7].SetActive(false);

        Image img = _teams[0].GetComponent<Image>();
        img.color = k_orange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RotateLeft()
    {
        if (_currentNavIndex <= 3)
        {
            return;
        }

        switch (_currentNavIndex)
        {
            case 4:
                _teams[4].transform.position = _teams[3].transform.position;
                _teams[4].SetActive(true);
                _teams[3].transform.position = _teams[2].transform.position;
                _teams[2].transform.position = _teams[1].transform.position;
                _teams[1].transform.position = _teams[0].transform.position;
                _teams[0].SetActive(false);
                break;
            case 5:
                _teams[5].transform.position = _teams[4].transform.position;
                _teams[5].SetActive(true);
                _teams[4].transform.position = _teams[3].transform.position;
                _teams[3].transform.position = _teams[2].transform.position;
                _teams[2].transform.position = _teams[1].transform.position;
                _teams[1].SetActive(false);
                break;
            case 6:
                _teams[6].transform.position = _teams[5].transform.position;
                _teams[6].SetActive(true);
                _teams[5].transform.position = _teams[4].transform.position;
                _teams[4].transform.position = _teams[3].transform.position;
                _teams[3].transform.position = _teams[2].transform.position;
                _teams[2].SetActive(false);
                break;
            case 7:
                _teams[7].transform.position = _teams[6].transform.position;
                _teams[7].SetActive(true);
                _teams[6].transform.position = _teams[5].transform.position;
                _teams[5].transform.position = _teams[4].transform.position;
                _teams[4].transform.position = _teams[3].transform.position;
                _teams[3].SetActive(false);
                break;
            default:
                break;
        }
    }
    
    private void RotateRight()
    {
        if (_currentNavIndex < 3)
        {
            return;
        }

        switch (_currentNavIndex)
        {
            case 3:
                _teams[0].transform.position = _teams[1].transform.position;
                _teams[0].SetActive(true);
                _teams[1].transform.position = _teams[2].transform.position;
                _teams[2].transform.position = _teams[3].transform.position;
                _teams[3].transform.position = _teams[4].transform.position;
                _teams[4].SetActive(false);
                break;
            case 4:
                _teams[1].transform.position = _teams[2].transform.position;
                _teams[1].SetActive(true);
                _teams[2].transform.position = _teams[3].transform.position;
                _teams[3].transform.position = _teams[4].transform.position;
                _teams[4].transform.position = _teams[5].transform.position;
                _teams[5].SetActive(false);
                break;
            case 5:
                _teams[2].transform.position = _teams[3].transform.position;
                _teams[2].SetActive(true);
                _teams[3].transform.position = _teams[4].transform.position;
                _teams[4].transform.position = _teams[5].transform.position;
                _teams[5].transform.position = _teams[6].transform.position;
                _teams[6].SetActive(false);
                break;
            case 6:
                _teams[3].transform.position = _teams[4].transform.position;
                _teams[3].SetActive(true);
                _teams[4].transform.position = _teams[5].transform.position;
                _teams[5].transform.position = _teams[6].transform.position;
                _teams[6].transform.position = _teams[7].transform.position;
                _teams[7].SetActive(false);
                break;
            default:
                break;
        }
    }

    private void OnClickLeft()
    {
        ReduceIndex();
        RotateRight();
    }

    private void OnClickRight()
    {
        AdvanceIndex();
        RotateLeft();
    }
    
    private void OnClickPlayButton()
    {
        SceneManager.LoadScene("MiniGamesTutorials");
    }

    private void AdvanceIndex()
    {
        if (_currentNavIndex >= 0 && !LeftScroller.gameObject.activeSelf)
        {
            LeftScroller.gameObject.SetActive(true);
        }

        if (_currentNavIndex == 6)
        {
            RightScroller.gameObject.SetActive(false);
        }

        Image currentImage = _teams[_currentNavIndex].GetComponent<Image>();
        currentImage.color = k_yellow;

        _currentNavIndex++;

        Image nextImage = _teams[_currentNavIndex].GetComponent<Image>();
        nextImage.color = k_orange;
    }
    
    private void ReduceIndex()
    {
        if (_currentNavIndex <= 7 && !RightScroller.gameObject.activeSelf)
        {
            RightScroller.gameObject.SetActive(true);
        }

        if (_currentNavIndex == 1)
        {
            LeftScroller.gameObject.SetActive(false);
        }
        
        Image currentImage = _teams[_currentNavIndex].GetComponent<Image>();
        currentImage.color = k_yellow;

        _currentNavIndex--;

        Image nextImage = _teams[_currentNavIndex].GetComponent<Image>();
        nextImage.color = k_orange;
    }
}
