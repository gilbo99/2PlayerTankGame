using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;


namespace Andrew
{


    public class TankOn : StateBase
    {
        public ArenaManager gameManager;

        public void OnEnable()
        {
            for (int i = 0; i < gameManager.active.Count; i++)
            {
                gameManager.active[i].gameObject.SetActive(true);
            }

        }

       
    }
    
    
   
}
