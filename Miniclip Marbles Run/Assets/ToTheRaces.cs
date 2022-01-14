using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ToTheRaces : MonoBehaviour
{
    public TextMeshProUGUI results; 
    public TextMeshProUGUI resultsAndWeights; 
    private void Start()
    {
       results.SetText($"Results from minigames\n\nMexican Wave: {MenuController.Instance.Minigame1Score} points\nIncentive Words: {MenuController.Instance.Minigame2Score} points");
       int total = (int) (MenuController.Instance.Minigame2Score + MenuController.Instance.Minigame1Score);

       int teamTotal = total;
       for (int i = 0; i < 7; i++)
       {
           MenuController.Instance.othersScores[i] = Random.Range(2045, 5567);
           teamTotal += MenuController.Instance.othersScores[i];
       }

       for (int i = 0; i < 7; i++)
       {
           MenuController.Instance.weightInVotes[i] = MenuController.Instance.othersScores[i]*1.0f / teamTotal;
       }

       MenuController.Instance.weightInVotes[7] = total * 1.0f / teamTotal;

       var scores = MenuController.Instance.othersScores;
       var weights = MenuController.Instance.weightInVotes;
       
       resultsAndWeights.SetText($"Total scores and weights for decisions of the driver:\n\nYou: {total} points, {string.Format("{0:0.00}", weights[7]*100)}");
       for (int i = 0; i < scores.Length; i++)
       {
           resultsAndWeights.SetText($"{resultsAndWeights.text}\nBot {i+1}: {scores[i]} points, {string.Format("{0:0.00}", weights[i]*100)}");
       }
    }

   public void TakeMeToTheRaces()
   {
      SceneManager.LoadScene("StockwellScene");
   }
}
