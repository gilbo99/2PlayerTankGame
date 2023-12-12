using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

namespace Andrew
{


    public class TankStats : MonoBehaviour, IDamage
    {

        //private UIManager uIManager;
        private GameManager gm;

        public int health;
        public string playerName;

        public GameObject attackingid;

        public delegate void UpdateHealth(int senthealth, GameObject owner);

        public event UpdateHealth setHealth;


        public delegate void Dead(GameObject tank);

        public event Dead sendDeadMessage;


        public void Awake()
        {
            gm = FindObjectOfType<GameManager>();
            //uIManager = FindObjectOfType<UIManager>();
        }

        public void TakeDamage(int damage, string enemyid, string Weapon)
        {
            health -= damage;
            //uIManager.SetPlayerHP(health, id);
            setHealth?.Invoke(health, gameObject);
            if (health <= 0)
            {
                Debug.Log("Player: " + (enemyid) + " Killed Player: " + (playerName) + " with " + Weapon);
                Destroy(this.gameObject);
            }
        }







        public void Damaged(int damage, string enemyid, string Weapon)
        {
            TakeDamage(damage, enemyid, Weapon);
        }


    }
}



