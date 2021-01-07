
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance
    {
        get
        {
            if (instance != null) 
                return instance;
                
            instance = FindObjectOfType<InputManager>();
            return instance;
        }
    }

    private PollManager pollManager;
    private Marble myMarble;

    private void GatherInstances()
    {        
        myMarble = RaceManager.Instance.marble1.GetComponent<Marble>();
        pollManager = PollManager.Instance;
    }


    public void CastVoteOnA()
    {
        GatherInstances();
        Poll.Ballot b;
        b.option = Poll.BallotOption.OptionA;
        b.weight = 1;
        pollManager.CastVote(myMarble.ID, b, 1);
    }
    
    public void CastVoteOnB()
    {
        GatherInstances();
        Poll.Ballot b;
        b.option = Poll.BallotOption.OptionB;
        b.weight = 1;
        pollManager.CastVote(myMarble.ID, b, 1);
    }
    
    public void CastVoteOnC()
    {
        GatherInstances();
        Poll.Ballot b;
        b.option = Poll.BallotOption.OptionC;
        b.weight = 1;
        pollManager.CastVote(myMarble.ID, b, 1);
    }
    
    public void CastVoteOnD()
    {
        GatherInstances();
        Poll.Ballot b;
        b.option = Poll.BallotOption.OptionD;
        b.weight = 1;
        pollManager.CastVote(myMarble.ID, b, 1);
    }
}
