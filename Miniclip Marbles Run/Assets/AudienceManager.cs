using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudienceManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreLabel;
    public TextMeshProUGUI GetReadyLabel;
    public TextMeshProUGUI rules_finishesIn_Label;
    public AudienceMember youInTheCrowd;
    public AudienceMember aboveYouInTheCrowd;
    public Button nextMiniGameButton;
    public MinigameTimer minigameTimer;
    
    public float Score;
    public float maxPoints = 10;
    public float diffSteps = 0.2f;
    private float initialDiff;

    private void Start()
    {
        nextMiniGameButton.gameObject.SetActive(false);
        initialDiff = Mathf.Abs(youInTheCrowd.transform.position.y - aboveYouInTheCrowd.transform.position.y);
        rules_finishesIn_Label.SetText("The closer you are to the crowd movement, the more points you'll get");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!minigameTimer.HasDelayExpired())
        {
            GetReadyLabel.enabled = true;
            GetReadyLabel.SetText($"Get Ready In: {string.Format("{0:0.00}", minigameTimer.Delay)}");
            return;
        }

        GetReadyLabel.enabled = false;
        ScoreLabel.gameObject.SetActive(true);
        if (minigameTimer.HasTimerExpired())
        {
            ScoreLabel.SetText($"You got: {Score} points");
            rules_finishesIn_Label.SetText($"Round Ended, great effort!");
            
            nextMiniGameButton.gameObject.SetActive(true);
            return;
        }
        
        rules_finishesIn_Label.SetText($"The closer you are to the crowd movement, the more points you'll get. \nRound finishes in {string.Format("{0:0.00}", minigameTimer.Timer)}");
        float youYPos = youInTheCrowd.transform.position.y;
        float aboveYouYPos = aboveYouInTheCrowd.transform.position.y;

        float diff = Mathf.Abs(youYPos - aboveYouYPos) - initialDiff;
        CalculateScore(diff);
        ScoreLabel.SetText($"Your score is:{Score} points");
    }

    private void CalculateScore(float diff)
    {
        var howManySteps = diff / diffSteps;
        var whichStepp = Mathf.Ceil(howManySteps);
        var pointsTakenFromThisStep = whichStepp * maxPoints / 10;
        if (pointsTakenFromThisStep >= 7)
            pointsTakenFromThisStep = maxPoints;
        
        var scoreDiff = maxPoints - pointsTakenFromThisStep;
        //Debug.Log($"howmany:{howManySteps} whichSte:{whichStepp}, pointsTaken:{pointsTakenFromThisStep}, scoreDif:{scoreDiff}, oldScore:{Score}");
        Score += scoreDiff;
    }

    public void NextMiniGame()
    {
        MenuController.Instance.Minigame1Score = Score;
        SceneManager.LoadScene("MiniGame2Scene");
    }
}
