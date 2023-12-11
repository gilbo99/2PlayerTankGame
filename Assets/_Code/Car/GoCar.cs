using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


namespace Andrew
{


    public class GoCar : MonoBehaviour , IDriveable
    {
        public Vector3 worldVelocity;
        public Vector3 localVelocity;
        public Vector3 forwardForce;
        public float turnSpeed;
        Rigidbody rb;
        public float speed;
        public float forceSpeed;
        public List<GameObject> turnWheel;
        private bool canMove;
        private bool breaking;
        public float turning;
        public float conSpeed;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }



        private void FixedUpdate()
        {
            
            worldVelocity = rb.velocity;
            localVelocity = transform.InverseTransformVector(worldVelocity);
            speed = worldVelocity.magnitude;

            turnWheel[0].transform.localRotation = Quaternion.Euler(0, turning * turnSpeed, 0);
            turnWheel[1].transform.localRotation = Quaternion.Euler(0, turning * turnSpeed, 0);



            if (conSpeed > .6)
            {
                forwardForce = new Vector3(0, 0, (conSpeed * forceSpeed));
                rb.AddRelativeForce(forwardForce);
            }

            if (conSpeed < -0.6)
            {
                forwardForce = new Vector3(0, 0, conSpeed * forceSpeed);
                rb.AddRelativeForce(forwardForce);
            }
                
                
               
            


        }

        public void Steer(InputAction.CallbackContext obj)
        {
            turning = obj.ReadValue<float>();
        
        }
        

        public void Break(InputAction.CallbackContext obj)
        {
            conSpeed = obj.ReadValue<float>();
         
        }

        public void Forward(InputAction.CallbackContext obj)
        {

            conSpeed = obj.ReadValue<float>();
        }
    }
}
