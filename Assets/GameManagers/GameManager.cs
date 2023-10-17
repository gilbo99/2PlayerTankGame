using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnLocation;

    public List<GameObject> itemSpawn;

    public List<GameObject> activeItem;
    
    public GameObject itembox;

    public List<GameObject> tank;

    public List<GameObject> active; 
    
    public new List<string> name;

    public bool gamePause = false;

    public int playing;

    public bool firstSetup = false;
    
    [SerializeField]
    private UIManager uIManager;

    public KeyCode pauseKey;

    public delegate void UpdateScore(int id);

    public event UpdateScore Score;
    
    
    public delegate void PauseGame();

    public event PauseGame pause;

    public void Update()
    {
        if (Input.GetKeyDown(pauseKey))     
        {
            if (gamePause)
            {
                for (int i = 0; i < active.Count; i++)
                {
                    active[i].GetComponent<IPauseable>().Pause();
                    pause?.Invoke();
                }
                
            }
            else
            {
                for (int i = 0; i < active.Count; i++)
                {
                    active[i].GetComponent<IPauseable>().UnPause();
                    pause?.Invoke();
                }
            }
            
            gamePause = !gamePause;
        }
    }

    //SetUpGame(how many player) game will spawn upto 4 players 
    // just is a spawn list of 4 spawn but will update too random locaions 
    public void SetUpGame()
    {
        if (firstSetup)
        {
            //uIManager.UpdateScore(active[0].GetComponent<TankStats>().id);
            Score?.Invoke(active[0].GetComponent<TankStats>().id);
        }
        Cursor.visible = false;
        ClearList();
        


        for (int i = 0; i < itemSpawn.Count; i++)
        {
            var clone = Instantiate(itembox, itemSpawn[i].transform.position, new Quaternion());
            activeItem.Add(clone);
            
        }
        
        
        for(int i = 0; i < playing; i++)
        {
            
            
            var clone = Instantiate(tank[i],spawnLocation[i].transform.position, transform.rotation);
            clone.gameObject.GetComponent<TankStats>().id = i;
            uIManager.HealthSubTo(clone);
            //tankLocation.Add(clone.transform);
            active.Add(clone);
            clone.GetComponent<TankStats>().sendDeadMessage += RemoveSub;
            var num = i + 1;
            name.Add("Player: " + num.ToString());
            uIManager.SetPlayerHP(clone.gameObject.GetComponent<TankStats>().health , i);
            
            
          
        }
        //uIManager.Toggle(false);
        firstSetup = true;
    }


   

    public void ClearList()
    {
        
        for (int i = 0; i < active.Count; i++)
        {
            Destroy(active[i]);
        }
        for (int i = 0; i < activeItem.Count; i++)
        {
            Destroy(activeItem[i]);
        }


        activeItem.Clear();
        active.Clear();
        name.Clear();
    }

    public void RemoveSub(GameObject tank)
    {
        
        Debug.Log("dead" + tank);
        uIManager.HealthUnSubTo(tank);
        tank.GetComponent<TankStats>().sendDeadMessage -= RemoveSub;
        
        if(active.Count == 1)
        {
            //uIManager.Toggle(true);
            Cursor.visible = true;
        }
        
        
        
    }
   
}
