using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpecialAbilities : MonoBehaviour
{
    private UIManager ui;
    
    public List<Ability> ability;
    
    private int shooterid;

    public void Start()
    {
        shooterid = this.GetComponent<TankStats>().id += 1; 
        Debug.Log("Tank id: " + shooterid);
        ui = FindObjectOfType<UIManager>();
        GetComponent<TankShoot>().specialShoot += Shoot;
    }
    

    private void Shoot()
    {
        if (ability != null)
        {
           
            Vector3 Spawn = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
            var clone = Instantiate(ability[0].item, Spawn, transform.rotation);
            SetWeapon(clone);

            ability = null;
        }
    }


    public void SetAbility(GameObject received)
    {
        //ability = received;
    }
/*
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<AbilitiesBox>() && ability == null)
        {
            ability = other.gameObject.GetComponent<AbilitiesBox>().SendItem();
            Destroy(other.gameObject);
        }
    }
    */

    private void SetWeapon(GameObject clone)
    {
        
        if (clone.TryGetComponent<Rocket>(out Rocket rocket))
        {
            rocket.SetID(shooterid);
        }else if (clone.TryGetComponent<Shield>(out Shield shield))
        {
            Vector3 Spawn = new Vector3(this.transform.position.x, this.transform.position.y + 0.37f, this.transform.position.z);
            shield.SetID(shooterid);
            shield.transform.position = Spawn;
            shield.transform.parent = transform;
            ui.ShieldOn(shooterid, true);
        }
        
    }


    private void OnDestroy()
    {
        GetComponent<TankShoot>().specialShoot -= Shoot;
    }
}


[Serializable]
public class Ability
{
    public GameObject item;
    public Transform spawn;
}
