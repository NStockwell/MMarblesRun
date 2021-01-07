using System;
using System.Collections.Generic;
using UnityEngine;

public class PollManager : MonoBehaviour
{
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
      polls.Add(new Poll());
    }
  }

  public void CastVote(int marbleId, Poll.Ballot ballot, int voterId)
  {
    if(marbleId >= polls.Count)
      return;
    
    polls[marbleId].CastVote(ballot.option, ballot.weight, voterId);
    
    ClosePoll(RaceManager.Instance.marble1.GetComponent<Marble>());
  }

  public void ClosePoll(Marble marble)
  {
    int marbleId = marble.ID;
    polls[marbleId].ApplyInputs(marble);
  }
}
