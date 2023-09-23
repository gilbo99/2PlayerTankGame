using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilities : MonoBehaviour
{
    
    public GameObject abilities;
    
    public KeyCode specialShoot;
    
    private int playerid;

    public void Start()
    {
        playerid = this.GetComponent<TankStats>().id; 
        Debug.Log("Tank id: " + playerid);
    }

    public void Update()
    {
        if (Input.GetKeyDown(specialShoot) && abilities != null)
        {
            Shoot();
            
        }
    }

    private void Shoot()
    {
        Vector3 Spawn = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
        var clone = Instantiate(abilities, Spawn, transform.rotation);
        SetWeaponID(clone);
        if (abilities != null && abilities.TryGetComponent<Mine>(out Mine mine)) 
        {
            Mines(clone);
        }
        abilities = null;
    }


    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pickup") && abilities == null)
        {
            abilities = other.gameObject.GetComponent<AbilitiesBox>().SendItem();
            Destroy(other.gameObject);
        }
    }

    public void Mines(GameObject clone)
    {
        Vector3 Spawn = new Vector3(this.transform.position.x + -3f, this.transform.position.y + 1f, this.transform.position.z);
        clone.transform.position = Spawn;
    }

    private void SetWeaponID(GameObject clone)
    {
        
        if (clone.TryGetComponent<Rocket>(out Rocket rocket))
        {
            rocket.SetID(playerid);
        }else if (clone.TryGetComponent<Shield>(out Shield shield))
        {
            shield.SetID(playerid);
            shield.transform.parent = transform;
        }
        
    }




}
