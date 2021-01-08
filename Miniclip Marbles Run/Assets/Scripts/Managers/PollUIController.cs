using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollUIController : MonoBehaviour
{
    // Start is called before the first frame update
    private Marble myMarble;
    public Slider Speed; // C
    public Slider Left; // A
    public Slider Right; // B
    public Slider Break; // D
    
    void Start()
    {
        myMarble = RaceManager.Instance.marble1.GetComponent<Marble>();
    }

    // Update is called once per frame
    void Update()
    {
        Poll poll = PollManager.Instance.polls[myMarble.ID];
        Speed.value = poll.CVotesPercentage;
        Left.value = poll.AVotesPercentage;
        Right.value = poll.BVotesPercentage;
        Break.value = poll.DVotesPercentage;
    }
}
