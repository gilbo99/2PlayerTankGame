using System;
using System.Collections;
using System.Collections.Generic;
using Andrew;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public StateBase CurrentState;
    public StateBase StartState;

    public void Start()
    {
        SwitchState(StartState);
    }




    public void SwitchState(StateBase newState)
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
