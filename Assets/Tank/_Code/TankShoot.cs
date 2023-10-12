using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    //button press
    public KeyCode shoot;
    public KeyCode specialItem;
    
    public GameObject bullet;
    public GameObject spawnbullet;
    

    public float cooldown;

    public int playerid;
    
    public delegate void SpecialShoot();
    public event SpecialShoot specialShoot;


    public void Start()
    {
        playerid = this.GetComponent<TankStats>().id;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (Input.GetKeyDown(shoot) && cooldown <= 0)
        {
            Shoot();
            

        }
        if (Input.GetKeyDown(specialItem))
        {
            specialShoot?.Invoke();
        }

    }



    private void Shoot()
    {
            Vector3 spawn = new Vector3(spawnbullet.transform.position.x, spawnbullet.transform.position.y, spawnbullet.transform.position.z);   
            var clone = Instantiate(bullet, spawn, transform.rotation);
           
            if (clone.TryGetComponent<Bullet>(out Bullet shot))
            {
                shot.SetID(playerid);
               
            }
            cooldown = bullet.GetComponent<Bullet>().cooldown;
    }
    
    
    
    
    
    
    
    
    public void SetID(int id)
    {
        playerid = id;
        Debug.Log("Shield ID set: " + playerid);
    }
    
}
