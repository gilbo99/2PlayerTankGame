using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    public float speed;
    public float boostSpeed;
    private float counter;
    public float timer;
    private Rigidbody rb;
    public int rotateSpeed;
    public KeyCode forward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode boost;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(forward))
        {

            rb.AddForce(transform.forward * speed);

        }

        if (Input.GetKey(left))
        {
            Vector3 rotateL = new(0, -rotateSpeed, 0);
            Quaternion deltaRotation = Quaternion.Euler(rotateL * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        if (Input.GetKey(right))
        {
            Vector3 rotateR = new(0, rotateSpeed, 0);
            Quaternion deltaRotation = Quaternion.Euler(rotateR * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        counter -= Time.deltaTime;
        if (Input.GetKey(boost) && counter <= 0)
        {
            if (Input.GetKey(left))
            {
                rb.velocity = -transform.right * boostSpeed;
            }else if (Input.GetKey(right))
            {
                rb.velocity = transform.right * boostSpeed;
            }
            else
            {
                rb.velocity = transform.forward * boostSpeed;
            }

            counter = timer;

        }
    }
    
    
    
   



}

    
 