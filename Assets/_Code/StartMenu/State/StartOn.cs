using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOn : MonoBehaviour
{
    public GameObject uiStart;
    private GameManager gm;
    public GameObject cam;

    public StartOff startOff;
    private void OnEnable()
    {
        gm = FindObjectOfType<GameManager>();
        uiStart.SetActive(true);
        
    }

    private void Update()
    {
        
    }

    private void OnDisable()
    {
        cam.SetActive(false);
    }

    public void StartGame()
    {
        gm.SetUpGame();
        GetComponent<StageManager>().SwitchState(startOff);
    }
}
