using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isFinish;
    public int order;
    
    private void OnTriggerEnter(Collider other)
    {
        Marble marble = other.gameObject.GetComponent<Marble>();
        
        // Notify race manager that a checkpoint was reached
        RaceManager.Instance.CheckpointReached(this, other.gameObject.GetComponent<Marble>());
        
        PollManager.Instance.ClosePoll(marble);

        if (isFinish)
        {
            // Reset Marble to starting position
            RaceManager.Instance.ResetMarble(other.gameObject);
        }
    }
}
