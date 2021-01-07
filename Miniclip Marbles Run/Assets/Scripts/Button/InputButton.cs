using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButton : MonoBehaviour
{
   public Poll.BallotOption option;
   public void OnButtonPress(){
      Debug.Log("Button clicked " + option + " times.");
   }
}
