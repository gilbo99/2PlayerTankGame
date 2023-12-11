using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankForce : MonoBehaviour
{
    public Vector3 localVelocity;
    public Vector3 worldVelocity;
    public Vector3 forwardForce;
    private Rigidbody rb;
    public float forceSpeed;
    public List<GameObject> turnWheel;
    public float turnSpeed;
    public float friction;
    public float side;
    public GilboInput gilboInput;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.AddRelativeForce(forwardForce);
        rb.AddRelativeForce(side, 0, 0);
     
        turnWheel[0].transform.localRotation = Quaternion.Euler(0, Input.GetAxisRaw("Horizontal") * turnSpeed, 0);
        turnWheel[1].transform.localRotation = Quaternion.Euler(0, Input.GetAxisRaw("Horizontal") * turnSpeed, 0);
        
        worldVelocity = rb.velocity;
        localVelocity = transform.InverseTransformVector(worldVelocity);
        
        
        side = -localVelocity.x * friction;
        forwardForce.z = Input.GetAxisRaw("Vertical") * forceSpeed;
    }
    
    
    
    public void Flip()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
