using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class Bullet : MonoBehaviour, IPauseable
{
    public new string name;
    
    private Rigidbody _rb;
    
    private GameManager gm;

    //Bullet Stats
    public int damage;
    public float speed;
    public float lifespan;
    public float cooldown;
    public int playerid;

    public bool pause = false;
    
    public Vector3 pauseSpeed;

    public Vector3 lastVelocity;
    public void Awake()
    {
        
        _rb = this.GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(this.gameObject, lifespan);
        gm = FindObjectOfType<GameManager>();
        
    }

    public void Start()
    {
        //gm.pause += Toggle;
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
            //other.gameObject.GetComponent<TankStats>().Damaged(damage, playerid, name);
            if (other.gameObject.GetComponent<IDamage>() != null)
            {
                other.gameObject.GetComponent<IDamage>().Damaged(damage, playerid, name);
            }

            


        }

        
    }

    public void Killme()
    {
        //gm.pause -= Toggle;
        Destroy(this.gameObject);
    }
    
    public void SetID(int id)
    {
        playerid = id;
       
    }

    public void Toggle()
    {
        
        if (pause)
        {
            Pause();
        }
        else
        {
            UnPause();
        }
        pause = !pause;
    }

    public void Pause()
    {
        
        pauseSpeed = _rb.velocity;
        _rb.velocity = new Vector3(0, 0, 0);
        Debug.Log(pauseSpeed);
        
    }

    public void UnPause()
    {
        _rb.velocity = pauseSpeed;
    }
}
