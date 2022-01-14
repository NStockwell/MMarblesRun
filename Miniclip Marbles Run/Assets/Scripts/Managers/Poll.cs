using System;
using System.Collections.Generic;
using UnityEngine;

public class Poll
{
  public int MarbleID;
  
  private float totalVotes;
  public float optionAVotes;
  public float optionBVotes;
  public float optionCVotes;
  public float optionDVotes;
  
  public float AVotesPercentage;
  public float BVotesPercentage;
  public float CVotesPercentage;
  public float DVotesPercentage;

  public enum BallotOption
  {
    OptionA,
    OptionB,
    OptionC,
    OptionD
  };
  public struct Ballot
  {
    public float weight;
    public BallotOption option;
  }

  private Dictionary<int, Ballot> castBallots = new Dictionary<int, Ballot>();

  public void CastVote(BallotOption option, float weight, int voterId)
  {
    Ballot ballot;
    bool ballotExists = castBallots.TryGetValue(voterId, out ballot);
    if(ballotExists) {
      switch (ballot.option)
      {
        case BallotOption.OptionA:
          optionAVotes -= ballot.weight;
          break;
        case BallotOption.OptionB:
          optionBVotes -= ballot.weight;
          break;
        case BallotOption.OptionC:
          optionCVotes -= ballot.weight;
          break;
        case BallotOption.OptionD:
          optionDVotes -= ballot.weight;
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      castBallots.Remove(voterId);
    }

    switch (option)
    {
      case BallotOption.OptionA:
        optionAVotes += weight;
        break;
      case BallotOption.OptionB:
        optionBVotes += weight;
        break;
      case BallotOption.OptionC:
        optionCVotes += weight;
        break;
      case BallotOption.OptionD:
        optionDVotes += weight;
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(option), option, null);
    }

    ballot.option = option;
    ballot.weight = weight;
    
    castBallots.Add(voterId, ballot);
    UpdateVoteCount();
  }

  public void UpdateVoteCount()
  {
    totalVotes = optionAVotes + optionBVotes + optionCVotes + optionDVotes;
    if (totalVotes == 0)
    {
      AVotesPercentage = 0;
      BVotesPercentage = 0;
      CVotesPercentage = 0;
      DVotesPercentage = 0;
      
    }
    else
    {
      AVotesPercentage = optionAVotes;
      BVotesPercentage = optionBVotes;
      CVotesPercentage = optionCVotes;
      DVotesPercentage = optionDVotes;
    }

    Debug.Log($"Percentages:{MarbleID} {AVotesPercentage}, {BVotesPercentage}, {CVotesPercentage}, {DVotesPercentage}");
  }

  public void ApplyInputs(Marble marble)
  {
    if (optionAVotes >= optionBVotes && optionAVotes >= optionCVotes && optionAVotes >= optionDVotes)
    {
      marble.ApplyLeftImpulse();
    }
    else if (optionBVotes >= optionAVotes && optionBVotes >= optionCVotes && optionBVotes >= optionDVotes)
    {
      marble.ApplyRightImpulse();
    } else if (optionCVotes >= optionAVotes && optionCVotes >= optionBVotes && optionCVotes >= optionDVotes)
    {
      marble.ApplySpeedImpulse();
    } else   
      marble.ApplyBreakImpulse();

    ClearPoll();
    UpdateVoteCount();
  }

  private void ClearPoll()
  {
    castBallots.Clear();
    optionAVotes = optionBVotes = optionCVotes = optionDVotes = 0;
  }
}
