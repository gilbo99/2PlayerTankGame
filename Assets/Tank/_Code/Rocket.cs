using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    public GameObject model;
    private Rigidbody rb;
    private GameManager gm;

    public new string name;

    
    public int playerID;
    
    //Rocket stats
    public int damage;
    public float speed;
    public float lifespan;
    public float dis;
    public float timer;
    
    private float previous = 0;
    
    
    
    public Transform target;
    
    public void Awake()
    {
        
        gm = FindObjectOfType<GameManager>();
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = transform.up * 25;
        Destroy(this.gameObject, lifespan);
        
    }

    
    // GetEnemey() will get the furthest tank and set target so FaceTarget() will have somewhere to go
    private void GetEnemey()
    {
        for (int i = 0; i < gm.active.Count; i++)
        {
            
            
            dis = Vector3.Distance(this.transform.position, gm.active[i].transform.position);
            if (dis >= previous)
            {
                previous = dis;
                target = gm.active[i].transform;
                
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
        if (timer <=  0)
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
            Destroy(this.gameObject);
            if (other.gameObject.GetComponent<TankStats>())
            {
                target = null;
                KillMe();
                other.gameObject.GetComponent<TankStats>().TakeDamage(damage, playerID, name);
                
                
            }
        }
    }
    
    public void SetID(int id)
    {
        playerID = id;
        Debug.Log("Rocket ID set: " + playerID);
    }

    public void KillMe()
    {
        Destroy(this.gameObject);
    }
    
}
