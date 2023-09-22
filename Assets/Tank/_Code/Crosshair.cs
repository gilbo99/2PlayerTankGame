using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject aim;

    public LayerMask mask;

    public GameObject crossHair;

    public GameObject test;


    public void Update()
    {
        RaycastHit hit;
        //Physics.Raycast(aim.transform.forward, );
        if (Physics.Raycast(aim.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask))
        {
            Debug.Log(hit.transform.position);
            
            if (test == null)
            { 
                test = Instantiate(crossHair,hit.transform.position, new Quaternion());
                Debug.Log("Spwan");

            }
            else
            {
                test.transform.position = hit.point;

                

            }
            

        }
        Debug.DrawRay(aim.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(aim.transform.position, test.transform.position);
    }
}
