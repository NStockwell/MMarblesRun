using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordValidator : MonoBehaviour
{

    public TextMeshProUGUI textToValidate;
    public TextMeshProUGUI reasonLabel;
    public TextMeshProUGUI validatedWords;
    public TextMeshProUGUI scoreLabel;
    public Image greeRedCheck;

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
