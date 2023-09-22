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
        if (Input.GetKeyDown(specialShoot) && abilities != null)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 Spawn = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
        Instantiate(abilities, Spawn, transform.rotation);

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
}
