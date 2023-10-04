using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnplayer : MonoBehaviour
{
    public GameObject tank;

    public Transform player1;


    public void Start()
    {
        
        Instantiate(tank,player1.position, player1.transform.rotation);
    }
}
