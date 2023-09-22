using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnLocation;

    public List<GameObject> tank;

    public List<GameObject> active; 
    
    public new List<string> name;

    public List<Transform> tankLocation;

    public int playing;
    
    [SerializeField]
    private UIManager uIManager;
    

    public void Awake()
    {
        SetUpGame();
    }

    
    //SetUpGame(how many player) game will spawn upto 4 players 
    // just is a spawn list of 4 spawn but will update too random locaions 
    public void SetUpGame()
    {

        for (int i = 0; i < active.Count; i++)
        {
            Destroy(active[i]);
            active.RemoveAt(i);
            
        }
        
        
        
        
        for(int i = 0; i < playing; i++)
        {
            uIManager.Toggle(false);
            var clone = Instantiate(tank[i],spawnLocation[i].transform.position, transform.rotation);
            clone.gameObject.GetComponent<TankStats>().id = i;
            tankLocation.Add(clone.transform);
            active.Add(clone);
            var num = i + 1;
            name.Add("Player: " + num.ToString());
            uIManager.SetPlayerHP(clone.gameObject.GetComponent<TankStats>().health , i);
           
            
          
        }
          
    }
}
