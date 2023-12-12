using System;
using System.Collections.Generic;
using UnityEngine;


public class SpecialAbilities : MonoBehaviour
{
    private UIManager ui;
    
    public List<Ability> ability;

    public void Start()
    {
        ui = FindObjectOfType<UIManager>();
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
            //rocket.SetID(shooterid);
        }else if (clone.TryGetComponent<Shield>(out Shield shield))
        {
            Vector3 Spawn = new Vector3(this.transform.position.x, this.transform.position.y + 0.37f, this.transform.position.z);
            //shield.SetID(shooterid);
            shield.transform.position = Spawn;
            shield.transform.parent = transform;
            //ui.ShieldOn(shooterid, true);
        }
        
    }
    
    


   
}


[Serializable]
public class Ability
{
    public GameObject item;
    public Transform spawn;
}
