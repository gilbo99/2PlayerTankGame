using System;
using UnityEngine;



namespace Andrew
{


    public class HoverCar : MonoBehaviour
    {
        public GameObject car;
        public float tyreRadius;
        public float upForce;

        public float wheelSpeedx;
        public GameObject rayPoint;
        public AnimationCurve springForce;

        [Range(0, 5000)] public float tireFriction;


        public bool turningWheel;

        public Rigidbody rb;

        public RaycastHit hitinfo;

        public float damping;



        private void FixedUpdate()
        {





            Physics.Raycast(rayPoint.transform.position, -transform.up, out hitinfo, tyreRadius, Int32.MaxValue,
                QueryTriggerInteraction.Ignore);
            if (hitinfo.collider != null)
            {
                Debug.DrawLine(transform.position, hitinfo.point, Color.green);
                var distance = hitinfo.distance / upForce;
                //rb.AddRelativeForce(0,distance,0);
                rb.AddForceAtPosition(transform.up * (EvaluateCurve(hitinfo.distance) * upForce), transform.position);
                rb.GetRelativePointVelocity(transform.position);
                Damping();
                TireFriction();

                var localVelocity = transform.InverseTransformDirection(car.GetComponent<GoCar>().localVelocity);
                rb.AddForceAtPosition(transform.forward * localVelocity.x, transform.position);
            }






        }



        public float EvaluateCurve(float position)
        {

            return springForce.Evaluate(position);

        }


        public void TireFriction()
        {
            wheelSpeedx = rb.GetPointVelocity(transform.position).magnitude;

            var localvel = transform.InverseTransformDirection(rb.GetPointVelocity(transform.position));

            rb.AddForceAtPosition(transform.right * (-localvel.x * tireFriction), transform.position);
            
            
            
            //rb.AddForceAtPosition(this.transform.right * wheelSpeedx.x, transform.position);


        }

        public void Damping()
        {


            var localvel = transform.InverseTransformDirection(rb.GetPointVelocity(transform.position));

            rb.AddForceAtPosition(transform.up * (-localvel.y * damping), transform.position);
            //rb.AddForceAtPosition(this.transform.right * wheelSpeedx.x, transform.position);


        }



    }
}
