using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    
    public float speed;
    private Rigidbody rb;
    public int rotateSpeed;
    public KeyCode forward;
    public KeyCode left;
    public KeyCode right;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
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
    }
    
    
    
   



}

    
 