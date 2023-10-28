using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springs : MonoBehaviour
{
    public GameObject Tank;
    public Rigidbody rb;
    
    public float tyreRadius;
    public float springForce;
    public float damping;
    public float wheelSpeed;
    
    public AnimationCurve springCurve;
    
    [Range(0,5000)]
    public float tireFriction;
    
    public RaycastHit hitinfo;
    public void FixedUpdate()
    {
        
        
        Physics.Raycast(transform.position, -transform.up, out hitinfo, tyreRadius, Int32.MaxValue, QueryTriggerInteraction.Ignore);
        if (hitinfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitinfo.point, Color.green);

            UpForce();
            TurningFriction();
            Damping();
            //GetWheelSpeed();
            
            
            var localVelocity = this.transform.InverseTransformDirection(Tank.GetComponent<TankForce>().localVelocity);
            rb.AddForceAtPosition(transform.forward * localVelocity.x , transform.position);
        }
    }

    private void TurningFriction()
    {
        wheelSpeed = rb.GetPointVelocity(transform.position).magnitude;

        var localvel = transform.InverseTransformDirection(rb.GetPointVelocity(transform.position));

        rb.AddForceAtPosition(transform.right * (-localvel.x * tireFriction), transform.position);
    }

    private void Damping()
    {
        var localvel = transform.InverseTransformDirection(rb.GetPointVelocity(transform.position));

        rb.AddForceAtPosition(transform.up * (-localvel.y * damping), transform.position);
    }

    private void GetWheelSpeed()
    {
        rb.GetRelativePointVelocity(transform.position);
    }

    private void UpForce()
    {
        rb.AddForceAtPosition(transform.up * (EvaluateCurve(hitinfo.distance) * springForce), transform.position);
    }


    private float EvaluateCurve(float position)
    {
        
        return springCurve.Evaluate(position);
        
    }
}
