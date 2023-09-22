using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    
    private GameManager gm;

    //Bullet Stats
    public int damage;
    public float speed;
    public float lifespan;
    public float cooldown;
    
    public void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(this.gameObject, lifespan);
        gm = FindObjectOfType<GameManager>();
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
