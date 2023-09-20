using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public int player = 0;
    public KeyCode shoot;


    public void Start()
    {
        SetPlayer();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(shoot))
        {
            
        }
    }




    public void SetPlayer()
    {
        switch (player)
        {
            case 0:
                shoot = KeyCode.LeftAlt;
                break;
            case 1:
                shoot = KeyCode.RightArrow;
                break;
        }
    }
    
}
