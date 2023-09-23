using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string name;
    
    private Rigidbody _rb;
    
    private GameManager gm;

    //Bullet Stats
    public int damage;
    public float speed;
    public float lifespan;
    public float cooldown;

    public int playerid;

    public Vector3 lastVelocity;
    public void Awake()
    {
        
        _rb = this.GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(this.gameObject, lifespan);
        gm = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        lastVelocity = _rb.velocity;
    }


    private void OnCollisionEnter(Collision other)
    {
        /*
        Vector3 inNormal = other.contacts[0].normal;
        Vector3  direction = Vector3.Reflect(_rb.velocity, inNormal);
        Debug.Log(direction);
        Quaternion face = new Quaternion(direction.x, direction.y, direction.z, 0);
        this.transform.rotation = face;
        _rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        */
       
        if (other.gameObject.GetComponent<TankStats>())
        {

            var speed2 = lastVelocity.magnitude;

            var dir = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
            _rb.velocity = dir * Mathf.Max(speed2, 0f);

            Killme();
            other.gameObject.GetComponent<TankStats>().TakeDamaged(damage, playerid, name);
            
        }

        
    }

    public void Killme()
    {
        Destroy(this.gameObject);
    }
    
    public void SetID(int id)
    {
        playerid = id;
       
    }
    
    
    
}
