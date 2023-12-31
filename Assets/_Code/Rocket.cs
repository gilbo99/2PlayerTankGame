using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Andrew
{


    public class Rocket : MonoBehaviour, IAbilitiesStats
    {
        public GameObject model;
        private Rigidbody rb;
        private GameManager gm;
        public Transform transform { get; set; }
        public GameObject owner { get; set; }
        public TankStats Playername;



        public int playerID;

        //Rocket stats
        public int damage;
        public float speed;
        public float lifespan;
        public float dis;
        public float timer;
        public Transform spawn;
        private float previous = 0;




        public Transform target;


        public void Awake()
        {

            gm = FindObjectOfType<GameManager>();
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.up * 25;
            Destroy(gameObject, lifespan);
            transform = spawn;

        }


        // GetEnemey() will get the furthest tank and set target so FaceTarget() will have somewhere to go
        private void GetEnemey()
        {
            for (int i = 0; i < gm.activePlayers.Count; i++)
            {

                if (gm != null)
                {
                    dis = Vector3.Distance(transform.position, gm.activePlayers[i].transform.position);
                    if (dis >= previous)
                    {
                        previous = dis;
                        target = gm.activePlayers[i].transform;

                    }
                }
            }
        }

        // FaceTarget() will rotate and push the rocket towards the target
        private void FaceTarget()
        {
            if (target != null)
            {
                Vector3 targetDirection = target.transform.position - transform.position;

                float singleStep = speed * Time.deltaTime;

                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

                Debug.DrawRay(transform.position, newDirection, Color.red);

                transform.rotation = Quaternion.LookRotation(newDirection);

                rb.velocity = transform.forward * speed;
                Vector3 test = Vector3.RotateTowards(transform.up, targetDirection, singleStep, 0.0f);
                model.transform.rotation = Quaternion.LookRotation(test);
            }
        }


        public void Update()
        {
            if (timer <= 0)
            {
                GetEnemey();
                FaceTarget();
            }

            timer -= Time.deltaTime;


        }

        private void OnCollisionEnter(Collision other)
        {
            if (timer <= 0)
            {
                Destroy(gameObject);
            }

            if (other.gameObject.GetComponent<TankStats>())
            {
                target = null;
                KillMe();
                other.gameObject.GetComponent<TankStats>().TakeDamage(damage, owner.GetComponent<TankStats>().playerName, name);


            }
        }

        

        public void KillMe()
        {
            Destroy(gameObject);
        }


    }
}