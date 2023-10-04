using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public List<GameObject> spawnLocation;
    public List<GameObject> itemSpawn;
    
    public GameObject itembox;
    
    public List<GameObject> tank;
    public List<GameObject> active; 
    
    public new List<string> name;
    
    public bool gamePause = false;

    public int playing = 2;
    
    public bool firstSetup = false;
    
    
    
    
    public KeyCode pauseKey;
    
    public delegate void UpdateScore(int id);

    public event UpdateScore Score;
    
    
    public delegate void PauseGame();

    public event PauseGame pause;


    public void Start()
    {
        SetUp();
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
        var clone = Instantiate(tank[i],spawn.position, spawn.rotation);
        clone.gameObject.GetComponent<TankStats>().id = i;
        active.Add(clone);
        var num = i + 1;
        name.Add("Player: " + num.ToString());

    }


    public void RestartLevel()
    {
        for (int i = 0; i < active.Count; i++)
        {
            Destroy(active[i]);
        }
        
        active.Clear();
        name.Clear();
    }

    
    
    
    
    
    
    
    
    
    
    
}
