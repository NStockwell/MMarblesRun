
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Marble Marble;
    public Vector3 offset;
    public float damping = 1;
    
    private Rigidbody marbleRigidbody;
    private Transform marbleTransform;
    
    private void Awake()
    {
        marbleTransform = Marble.transform;
        marbleRigidbody = Marble.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        var velocity = marbleRigidbody.velocity.normalized;
        var velocityX = velocity.x;
        var velocityZ = velocity.z;

        float desiredAngle = Mathf.Atan2(velocityX, velocityZ)* Mathf.Rad2Deg;
        float currentAngle = transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
        
        Quaternion rotation = Quaternion.Euler(30,angle+180,0);
        transform.position = marbleTransform.position + rotation*offset;
        transform.LookAt(marbleTransform.position);
    }
}
