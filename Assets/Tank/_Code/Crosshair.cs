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
        MakeCrossHair();
    }

    public void OnDrawGizmos()
    {
        if (aim != null && test!= null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(aim.transform.position, test.transform.position);
        }
    }

    public void MakeCrossHair()
    {
        RaycastHit hit;
        //Physics.Raycast(aim.transform.forward, );
        if (Physics.Raycast(aim.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask))
        {
            if (test == null)
            { 
                test = Instantiate(crossHair,hit.transform.position, new Quaternion());

                test.transform.parent = this.transform;
            }
            else
            {
                test.transform.position = hit.point;

            }
            

        }
        Debug.DrawRay(aim.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
    }
}
