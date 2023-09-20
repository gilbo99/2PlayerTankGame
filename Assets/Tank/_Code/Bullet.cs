using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;

    public float speed;
    private Rigidbody rb;
    // Update is called once per frame
    public void Awake()
    {
        rb = bullet.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.AddForce(transform.up * speed, ForceMode.Impulse);
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
