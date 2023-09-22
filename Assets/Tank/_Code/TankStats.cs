using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStats : MonoBehaviour
{
    
    private UIManager uIManager;

    private GameManager gm;
    

    public int health;
    public int id;

    public void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        uIManager = FindObjectOfType<UIManager>();
    }

    public void TakeDamaged(int damage)
    {
        health -= damage;
        uIManager.SetPlayerHP(health, id);
        if (health <= 0)
        {
            gm.active.RemoveAt(id);
            Destroy(this.gameObject);
        }
    }


    private void OnDestroy()
    {
        if (gm.active.Count == 1)
        {
            uIManager.Toggle(true);
            Cursor.visible = true;
        }
    }
}
