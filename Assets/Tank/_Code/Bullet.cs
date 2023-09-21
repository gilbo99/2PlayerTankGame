using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    
    private Rigidbody rb;

    public int damage;
    public float speed;
    public float lifespan;
    public float cooldown;
    
    public void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(this.gameObject, lifespan);
    }

    public void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<TankStats>())
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<TankStats>().TakeDamaged(damage);
            
        }
    }
    
    
    
    
    
    
    /*
    private void OnCollisionEnter(Collision collision) 
    {
        Vector3 inNormal = collision.contacts[0].normal;
        Vector3  direction = Vector3.Reflect(rb.velocity, inNormal);
        Debug.Log(direction);
        Quaternion face = new Quaternion(direction.x, direction.y, direction.z, 0);
        bullet.transform.rotation = face;
    }   
    */
}
