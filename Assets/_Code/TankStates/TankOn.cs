using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class TankOn : MonoBehaviour
{
    public GameManager gm;
    public void OnEnable()
    {
        for (int i = 0; i < gm.active.Count; i++)
        {
            gm.active[i].GetComponent<IPauseable>().UnPause();
        }
            
    }

    public void OnDisable()
    {
        
    }
}
