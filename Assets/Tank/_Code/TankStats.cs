using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStats : MonoBehaviour
{
    
    private UIManager uIManager;

    public int health;
    public int id;

    public void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        uIManager.SetPlayerHP(health, id);
    }

    public void TakeDamaged(int damage)
    {
        health -= damage;
        uIManager.SetPlayerHP(health, id);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
