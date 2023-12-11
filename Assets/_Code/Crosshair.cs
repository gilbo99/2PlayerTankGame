using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject aim;
    public LayerMask mask;
    public GameObject crossHair_PreFab;
    private GameObject crossHair;


    public void Update()
    {
        MakeCrossHair();
    }
    

    public void MakeCrossHair()
    {
        RaycastHit hit;
        //Physics.Raycast(aim.transform.forward, );
        if (Physics.Raycast(aim.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask))
        {
            if (crossHair == null)
            { 
                crossHair = Instantiate(crossHair_PreFab,hit.transform.position, new Quaternion());

                crossHair.transform.parent = this.transform;
            }
            else
            {
                crossHair.transform.position = hit.point;

            }
           

        }
        Debug.DrawRay(aim.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
    }
}
