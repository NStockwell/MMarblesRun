using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTheRaces : MonoBehaviour
{
   private void Start()
   {
     // MenuController.Instance.Minigame1Score;
     // MenuController.Instance.Minigame2Score;
   }

   public void TakeMeToTheRaces()
   {
      SceneManager.LoadScene("StockwellScene");
   }
}
