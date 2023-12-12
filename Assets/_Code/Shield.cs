using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour, IAbilitiesStats
{
    public int shieldHP;
    
    public Transform transform { get; set;}
    public GameObject owner { get; set; }

    private UIManager ui;

    public GameObject shotID;

    public Transform spawn;
    
    public delegate void ShieldDestroy();

    public event ShieldDestroy shielDestroy;
    

    public void Awake()
    {
        transform = spawn;
        
        ui = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
       
     
        

        if (shieldHP <= 0)
        {
            Destroy(this.gameObject);
        }



    }


    public void SetOwner(GameObject tank)
    {
        owner = tank;
    }

    
    /*
    public int IDCheck()
    {
        int id = 0;
        if (shotID.CompareTag("Bullet"))
        {
            id = shotID.GetComponent<Bullet>().playerid;
        }else if (shotID.CompareTag("Rocket"))
        {
            id = shotID.GetComponent<Rocket>().playerID;
        }else if (shotID.CompareTag("Mine"))
        {
            id = shotID.GetComponent<Mine>().playerID;
        }
        return id;
    }

*/
    
    public void OnDestroy()
    {
        shielDestroy?.Invoke();
        //ui.ShieldOn(owner , false);
    }

    
}
