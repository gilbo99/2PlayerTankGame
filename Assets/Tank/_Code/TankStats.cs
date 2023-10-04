using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class TankStats : MonoBehaviour, IDamage
{
    
    //private UIManager uIManager;
    private GameManager gm;
    

    public int health;
    public int id;

    public int attackingid;

    public delegate void UpdateHealth(int senthealth, int sendid);
    public event UpdateHealth setHealth;


    public delegate void Dead(GameObject tank, int sendID);

    public event Dead sendDeadMessage;
        
    
    public void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        //uIManager = FindObjectOfType<UIManager>();
    }

    public void TakeDamage(int damage, int enemyid, string Weapon)
    {
        health -= damage;
        //uIManager.SetPlayerHP(health, id);
        setHealth?.Invoke(health, id);
        if (health <= 0)
        {
            Debug.Log("Player: " + (enemyid+1) + " Killed Player: " + (id+1) + " with " + Weapon);
            Destroy(this.gameObject);
        }
    }


    
   
    private void OnDestroy()
    {
        //uIManager.HealthUnSubTo(this.gameObject);
        sendDeadMessage?.Invoke(this.gameObject, id);
    }


    public void Damaged(int damage, int enemyid, string Weapon)
    {
        TakeDamage(damage, enemyid, Weapon);
    }
}


