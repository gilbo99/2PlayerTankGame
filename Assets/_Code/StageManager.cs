using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public MonoBehaviour CurrentState;
    public MonoBehaviour StartState;

    public void Start()
    {
        SwitchState(StartState);
    }




    public void SwitchState(MonoBehaviour newState)
    {
        if (newState == CurrentState)
        {
            return;
        }

        if (CurrentState != null)
        {
            CurrentState.enabled = false;
        }

        newState.enabled = true;
        
        CurrentState = newState;

    }
}
