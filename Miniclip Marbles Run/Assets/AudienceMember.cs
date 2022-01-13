using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Mathf;

public class AudienceMember : MonoBehaviour
{
    private float accumulatedTime = 0;
    public bool you;
    private float initalPosY;
    private float delay;
    private bool buttonIsBeingPressed = false;
    public float youRate = 2.1f;
    public float theyCycle = 180;
    

    private void Start()
    {
        initalPosY = transform.position.y;
        accumulatedTime = 270 * Deg2Rad;
        delay = (transform.position.x + 10) / 4f;
    }
    
    public void OnButtonDown()
    {
        buttonIsBeingPressed = true;
    }

    public void OnButtonUp()
    {
        buttonIsBeingPressed = false;
    }

    void FixedUpdate()
    {
        float newYPos = UpdateMemberYPos();
        transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
    }

    private float UpdateMemberYPos()
    {
        if (you)
        {
            float offset = Time.fixedDeltaTime * youRate * (buttonIsBeingPressed ? 1 : -1);
            float newYPos = Mathf.Clamp(transform.position.y + offset, initalPosY, initalPosY + 2);
            
            //Debug.Log($" newYpos: {newYPos}, offset{offset}, {buttonIsBeingPressed}");
            return newYPos;
        }

        return UpdateOthersMemberYPos();
    }

    private float UpdateOthersMemberYPos()
    {
        //Debug.Log($"X:{transform.position.x}, d:{delay}");

        if (delay > 0)
        {
            delay -= Time.fixedDeltaTime;
            return initalPosY;
        }

        float remainTime = Time.fixedDeltaTime;
        if (delay < 0)
        {
            remainTime = -delay;
            delay = 0;
        }

        var np = Sin(accumulatedTime) + 1 + initalPosY;
        accumulatedTime += Deg2Rad * remainTime * theyCycle;
        return np;
    }
}
