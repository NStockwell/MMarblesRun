using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Toggle = UnityEngine.UI.Toggle;

public class PollManager : MonoBehaviour
{

  public Toggle Speed;
  public Toggle Break;
  public Toggle Left;
  public Toggle Right;
  
  private static PollManager instance;
  public static PollManager Instance
  {
    get
    {
      if (instance != null) 
        return instance;
                
      instance = FindObjectOfType<PollManager>();
      return instance;
    }  
  }

  public List<Poll> polls;

  private void Awake()
  {
    polls = new List<Poll>(8);
    for (int i = 0; i < 8; i++)
    {
      var newPoll = new Poll();
      newPoll.MarbleID = i;
      polls.Add(newPoll);
    }
  }

  public void CastVote(int marbleId, Poll.Ballot ballot, int voterId)
  {
    if(marbleId >= polls.Count)
      return;
    
    polls[marbleId].CastVote(ballot.option, ballot.weight, voterId);
  }

  public void ClosePoll(Marble marble)
  {
    int marbleId = marble.ID;
    polls[marbleId].ApplyInputs(marble);
    BotsVote(marble);

    var mymarble = RaceManager.Instance.marble1.GetComponent<Marble>();
    if(marbleId == mymarble.ID)
      ResetToggles();
  }

  private void ResetToggles()
  {
    Speed.isOn = false;
    Break.isOn = false;
    Left.isOn = false;
    Right.isOn = false;
  }

  private void BotsVote(Marble marble)
  {
    for (int i = 0; i < 7; i++)
    {
      Poll.Ballot ballot = new Poll.Ballot();
      ballot.weight = MenuController.Instance.weightInVotes[i];
      int option = Random.Range(0, 4);
      switch (option)
      {
        case 0:
          ballot.option = Poll.BallotOption.OptionA;
          break;
        case 1:
          ballot.option = Poll.BallotOption.OptionB;
          break;
        case 2:
          ballot.option = Poll.BallotOption.OptionC;
          break;
        case 3:
          ballot.option = Poll.BallotOption.OptionD;
          break;
      }
      CastVote(marble.ID, ballot, i*10);
      polls[marble.ID].UpdateVoteCount();
    }
  }
}
