using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnLocation;

    public List<GameObject> tank;

    public int playing;

    public int idcount;
    
    [SerializeField]
    private UIManager uIManager;
    

    public void Awake()
    {
        SetUpGame(playing);
    }

    private void SetUpGame(int player)
    {
        for(int i = 0; i < player; i++)
        {
            
            var clone = Instantiate(tank[i],spawnLocation[i].transform.position, transform.rotation);
            clone.gameObject.GetComponent<TankStats>().id = idcount;
            uIManager.SetPlayerHP(5 , idcount);
            idcount++;
            
          
        }
          
    }
}
