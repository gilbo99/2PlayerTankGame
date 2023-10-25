using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Andrew
{


    public class StateBase : MonoBehaviour
    {
        public StageManager stageManager;
        

        public void Awake()
        {
            stageManager = this.GetComponent<StageManager>();
            
        }

        
        
        
    }
}
