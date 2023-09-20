using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public GameObject tank;
    public float tank_Speed;
    private Rigidbody rb;
    public int Tank_RotateSpeed;
    public int player;
    public KeyCode forward;
    public KeyCode left;
    public KeyCode right;

    
    public void Start()
    {
        SetPlayer();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(forward))
        {

            rb.AddForce(-transform.right * tank_Speed);

        }
        if(Input.GetKey(left))
        {
            Vector3 rotateL = new(0, -Tank_RotateSpeed, 0);
            Quaternion deltaRotation = Quaternion.Euler(rotateL * Time.fixedDeltaTime); 
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        if (Input.GetKey(right))
        {
            Vector3 rotateR = new(0, Tank_RotateSpeed, 0);
            Quaternion deltaRotation = Quaternion.Euler(rotateR * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }






    public void SetPlayer()
    {
        switch(player)
        {
            case 0:
                forward = KeyCode.W;
                left = KeyCode.A;
                right = KeyCode.D;
                break;
            case 1:
                forward = KeyCode.UpArrow;
                left = KeyCode.LeftArrow;
                right = KeyCode.RightArrow;
                break;
        }

    }
}
 