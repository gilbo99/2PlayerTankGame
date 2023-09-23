using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int shieldHP;

    private int playerid;

    public GameObject shotID;
    private void OnTriggerEnter(Collider other)
    {
        
        shotID = other.gameObject;

        if (shotID.CompareTag("Bullet") && playerid != IDCheck())
        {
            shieldHP -= shotID.GetComponent<Bullet>().damage;
            shotID.GetComponent<Bullet>().Killme();
        }
        else if (shotID.CompareTag("Rocket") && playerid != IDCheck())
        {
            shieldHP -= shotID.GetComponent<Rocket>().damage;
            shotID.GetComponent<Rocket>().KillMe();
        }else if (shotID.CompareTag("Mine") && playerid != IDCheck())
        {
            shieldHP -= shotID.GetComponent<Mine>().damage;
        }

        if (shieldHP <= 0)
        {
            Destroy(this.gameObject);
        }



    }


    public void SetID(int id)
    {
        playerid = id;
        
    }

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
        
}
