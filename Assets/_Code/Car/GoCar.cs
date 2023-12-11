using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Andrew
{


    public class GoCar : MonoBehaviour , IDriveable
    {
        public Vector3 worldVelocity;
        public Vector3 localVelocity;
        public Vector3 localDirection;
        public Vector3 forwardDirection;
        public float speed;
        public Vector3 direction;
        public Vector3 forwardForce;
        public float turnSpeed;
        Rigidbody rb;
        public float forceSpeed;
        public float steering;
        public List<GameObject> turnWheel;
        private bool canMove;
        private bool breaking;
        private float turning;

        public float timer;

        public float breakForce;
        //public GilboInput gilboInput;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }



        private void FixedUpdate()
        {
            
            worldVelocity = rb.velocity;
            forwardDirection = transform.forward;
            localVelocity = transform.InverseTransformVector(worldVelocity);
            localDirection = transform.InverseTransformDirection(worldVelocity);
            speed = worldVelocity.magnitude;
            direction = worldVelocity.normalized;

            turnWheel[0].transform.localRotation = Quaternion.Euler(0, turning * turnSpeed, 0);
            turnWheel[1].transform.localRotation = Quaternion.Euler(0, turning * turnSpeed, 0);


            if (canMove)
            {

                forwardForce = new Vector3(0, 0, forceSpeed);
                rb.AddRelativeForce(forwardForce);
            }

            if (breaking)
            {
                forwardForce = new Vector3(0, 0, forceSpeed / breakForce);
                rb.AddRelativeForce(-forwardForce);
            }


        }

        public void Steer(InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }
        

        public void Break(InputAction.CallbackContext obj)
        {
           
         
        }

        public void Forward(InputAction.CallbackContext obj)
        {
            canMove = true;
        }
    }
}
