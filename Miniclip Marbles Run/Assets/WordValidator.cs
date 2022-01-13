using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordValidator : MonoBehaviour
{
    public TextMeshProUGUI textToValidate;
    public TextMeshProUGUI reasonLabel;
    public TextMeshProUGUI validatedWords;
    public TextMeshProUGUI rules_finishesIn_Label;
    public TextMeshProUGUI getReadyLabel;
    public TextMeshProUGUI scoreLabel;
    public Image greeRedCheck;
    public MinigameTimer minigameTimer;

    public Button buttonP;
    public Button buttonT;
    public Button buttonA;
    public Button buttonO;
    public Button buttonValidate;
    public Button buttonClear;
    public Button nextSceneButton;

    public List<string> validWords = new List<string>();
    private List<string> acceptedWords = new List<string>();

    private double Score = 0;
    
    enum RejectReason
    {
        Invalid = 1, 
        AlreadyUsed = 2, 
        TooLong = 3,
        TooShort = 4
    }
    public void Validate()
    {
        string currentString = textToValidate.text;

        if (currentString.Length > 4)
        {
            RejectWord(RejectReason.TooLong);
            Clear();
            return;
        }

        if (currentString.Length < 2)
        {
            RejectWord(RejectReason.TooShort);
            Clear();
            return;
        }
        
        foreach (var acceptedWord in acceptedWords)
        {
            if (acceptedWord.Equals(currentString, StringComparison.InvariantCultureIgnoreCase))
            {
                RejectWord(RejectReason.AlreadyUsed);
                Clear();
                return;
            }
        }

        foreach (var validWord in validWords)
        {
            if (validWord.Equals(currentString, StringComparison.InvariantCultureIgnoreCase))
            {
                AcceptWord(currentString);
                Clear();
                return;
            }
        }
        
        RejectWord(RejectReason.Invalid);
        Clear();
    }

    private void AcceptWord(string currentString)
    {
        greeRedCheck.color = Color.green;
        acceptedWords.Add(currentString);
        validatedWords.text += $"\n{currentString}";
        Score += Math.Pow(2, currentString.Length)*40;
        scoreLabel.SetText($"Score: {Score}");
        reasonLabel.text = $"Accepted the word: {currentString}";
    }

    private void RejectWord(RejectReason reason)
    {
        switch (reason)
        {
            case RejectReason.Invalid:
                greeRedCheck.color = Color.red;
                reasonLabel.SetText("Invalid English word");
                break;
            case RejectReason.AlreadyUsed:
                greeRedCheck.color = Color.yellow;
                reasonLabel.SetText("Word already used before");
                break;
            case RejectReason.TooLong:
                greeRedCheck.color = Color.red;
                reasonLabel.SetText("Word longer than 4 letters");
                break;
            case RejectReason.TooShort:
                greeRedCheck.color = Color.red;
                reasonLabel.SetText("Word shorter than 2 letters");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(reason), reason, null);
        }
    }

    public void Clear()
    {
        textToValidate.text = "";
    }

    public void PressedP()
    {
        textToValidate.text = $"{textToValidate.text}P";
    }
    
    public void PressedT()
    {
        textToValidate.text = $"{textToValidate.text}T";
    }
    
    public void PressedA()
    {
        textToValidate.text = $"{textToValidate.text}A";
    }
    
    public void PressedO()
    {
        textToValidate.text = $"{textToValidate.text}O";
    }

    private void EnableAllButtons(bool enable)
    {
        if(buttonA.interactable == enable)
            return;
        
        buttonP.interactable = enable;
        buttonT.interactable = enable;
        buttonA.interactable = enable;
        buttonO.interactable = enable; 
        buttonValidate.interactable = enable; 
        buttonClear.interactable = enable;
    }


    private void FixedUpdate()
    {
        if (!minigameTimer.HasDelayExpired())
        {
            EnableAllButtons(false);
            getReadyLabel.enabled = true;
            getReadyLabel.SetText($"Get Ready In: {string.Format("{0:0.00}", minigameTimer.Delay)}");
            return;
        }

        EnableAllButtons(true);
        getReadyLabel.enabled = false;
        scoreLabel.gameObject.SetActive(true);
        
        if (minigameTimer.HasTimerExpired())
        {
            EnableAllButtons(false);
            nextSceneButton.gameObject.SetActive(true);
            scoreLabel.SetText($"You got: {Score} points");
            rules_finishesIn_Label.SetText($"Round Ended, great effort!");
            return;
        }
        
        rules_finishesIn_Label.SetText($"Write as many 2, 3 or 4 letters words within the time limit. \nRound finishes in {string.Format("{0:0.00}", minigameTimer.Timer)}");
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene("MiniGamesResults");
    }
}
