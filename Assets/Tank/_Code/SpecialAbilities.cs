using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilities : MonoBehaviour
{
    
    public GameObject abilities;
    
    public KeyCode specialShoot;


  

    public void Update()
    {
        if (Input.GetKeyDown(specialShoot))
        {
             
            Vector3 Spawn = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);   
            Instantiate(abilities, Spawn, transform.rotation);  
            
        }
    }
}
