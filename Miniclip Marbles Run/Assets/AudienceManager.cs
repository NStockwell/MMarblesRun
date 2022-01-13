using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudienceManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreLabel;
    public TextMeshProUGUI GetReadyLabel;
    public TextMeshProUGUI CloserToTheCrowdLabel;
    public AudienceMember youInTheCrowd;
    public AudienceMember aboveYouInTheCrowd;
    public float Score;
    public float maxPoints = 10;
    public float diffSteps = 0.2f;
    private float initialDiff;

    public float timer = 5f;
    public float delay = 3f;
    
    private void Start()
    {
        initialDiff = Mathf.Abs(youInTheCrowd.transform.position.y - aboveYouInTheCrowd.transform.position.y);
        CloserToTheCrowdLabel.SetText("The closer you are to the crowd movement, the more points you'll get");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (delay > 0)
        {
            GetReadyLabel.enabled = true;
            GetReadyLabel.SetText($"Get Ready In: {string.Format("{0:0.00}", delay)}");
            delay -= Time.fixedDeltaTime;
            return;
        }

        GetReadyLabel.enabled = false;
        ScoreLabel.gameObject.SetActive(true);
        if (timer < 0)
        {
            ScoreLabel.SetText($"You got: {Score} points");
            CloserToTheCrowdLabel.SetText($"Round Ended, great effort!");
            return;
        }

        timer -= Time.fixedDeltaTime;

        
        CloserToTheCrowdLabel.SetText($"The closer you are to the crowd movement, the more points you'll get. \nRound finishes in {string.Format("{0:0.00}", timer)}");
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
        Debug.Log($"howmany:{howManySteps} whichSte:{whichStepp}, pointsTaken:{pointsTakenFromThisStep}, scoreDif:{scoreDiff}, oldScore:{Score}");
        Score += scoreDiff;
    }
}
