using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class TankShoot : MonoBehaviour
{
    public KeyCode shoot;
    public GameObject bullet;
    public GameObject spawnbullet;

    public float cooldown;

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (Input.GetKeyDown(shoot)&& cooldown <= 0)
        {
            
            Vector3 Spawn = new Vector3(spawnbullet.transform.position.x, spawnbullet.transform.position.y, spawnbullet.transform.position.z);   
            Instantiate(bullet, Spawn, transform.rotation);  
            cooldown = bullet.GetComponent<Bullet>().cooldown;
        }
    }
    
}
