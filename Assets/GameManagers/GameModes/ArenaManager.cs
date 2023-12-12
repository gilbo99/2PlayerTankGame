using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Andrew;

public class ArenaManager : MonoBehaviour
{
    public List<GameObject> spawnLocation;
    public List<GameObject> itemSpawn;
    
    public GameObject itembox;
    
    public List<GameObject> tank;
    public List<GameObject> active; 
    
    public List<string> playerName;
    
    public bool gamePause = false;

    public int playing = 2;
    
    public bool firstSetup = false;
    
    
    
    
    public KeyCode pauseKey;
    
    public delegate void UpdateScore(string id);

    public event UpdateScore Score;
    
    
    public delegate void PauseGame();

    public event PauseGame pause;
    
    public delegate void SetupUI(int players);

    public event SetupUI uiSetup;
    


    public void Start()
    {
        SetUp();
        uiSetup?.Invoke(playing);
        
    }


    public void SetUp()
    {
        RestartLevel();
        
        for (int i = 0; i < playing; i++)
        {

            SpawnPlayers(i, spawnLocation[i].transform);
        }
    }


    public void SpawnPlayers(int i,Transform spawn)
    {
        var num = i + 1;
        var clone = Instantiate(tank[i],spawn.position, spawn.rotation);
        clone.gameObject.GetComponent<TankStats>().playerName = ("Player: " + num);
        clone.GetComponent<TankStats>().sendDeadMessage += RemovePlayer;
        active.Add(clone);
        playerName.Add("Player: " + num);

    }


    public void RestartLevel()
    {
        for (int i = 0; i < active.Count; i++)
        {
            Destroy(active[i]);
        }
        
        active.Clear();
        playerName.Clear();
    }



    private void RemovePlayer(GameObject player)
    {
        for (int i = 0; i < active.Count; i++)
        {
            if(  active[i] == player)
            {
                active[i].GetComponent<TankStats>().sendDeadMessage -= RemovePlayer;
                active.RemoveAt(i);
            }
        }

        if (active.Count == 1)
        {
            Score?.Invoke(active[0].GetComponent<TankStats>().playerName);
        }
    }

    
}
