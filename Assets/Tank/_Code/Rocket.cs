using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    public GameObject rocket;
    private Rigidbody rb;
    private GameManager gm;
    
    public int damage;
    public float speed;
    public float lifespan;
    public float cooldown;
    public float dis;
    
    private float previous = 0;
    
    public GameObject target;
    public void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        rb = this.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * speed, ForceMode.Impulse);
        Destroy(this.gameObject, lifespan);
        GetEnemey();
    }
    

    public void GetEnemey()
    {
        for (int i = 0; i < gm.playing; i++)
        {

            dis = Vector3.Distance(this.transform.position, gm.tank[i].transform.position);
            if (dis >= previous)
            {

                target = gm.tank[i];
                previous = dis;
            }
        }
        Debug.Log(target.transform.position);
       
    }


    public void Update()
    {
        /*
        var lookPos = target.transform.forward - transform.position;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
        */

        transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 5f);
    
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<TankStats>())
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<TankStats>().TakeDamaged(damage);
            
        }
    }
    
}
